using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    SpriteRenderer spriteFB;
    Rigidbody2D body;
    Animator anim;

    bool Explodir = false;
    bool Terreno = false;
    bool Inimigo = false;
    bool MandarDmg = false;

    public int mg2;

    float DanoBase = 70;
    float KnockBack = 10f;

    public GameObject BolaDeFogo;
    public Transform ChecarContato;
    public LayerMask CamadaTerreno;
    public LayerMask CamadaInimigo;
    public float RaioColisão = 0.33f;
    
    // Start is called before the first frame update
    void Start()
    {

        spriteFB = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(BolaDeFogo, 4f);

    }

    // Update is called once per frame
    void Update()
    {

        DanoBase = DanoBase + (20 * mg2);

        if (spriteFB.flipX == false) { if (Explodir == false) { body.velocity = new Vector2(8, 0); } }
        if (spriteFB.flipX == true) { if (Explodir == false) { body.velocity = new Vector2(-8, 0); } }

        Terreno = Physics2D.OverlapCircle(ChecarContato.position, RaioColisão, CamadaTerreno);
        Inimigo = Physics2D.OverlapCircle(ChecarContato.position, RaioColisão, CamadaInimigo);
        Collider2D[] InimigosAtacados = Physics2D.OverlapCircleAll(ChecarContato.position, RaioColisão, CamadaInimigo);

        if (Terreno == true) { }

        else if (Inimigo == true)
        {

            body.velocity = new Vector2(8, 0);

            if (MandarDmg == false)
            {

                Debug.Log(DanoBase);
                InimigosAtacados[0].SendMessage("LevarDano", DanoBase);
                InimigosAtacados[0].SendMessage("KnockBack", KnockBack);
                Debug.Log(InimigosAtacados[0].name);
                MandarDmg = true;

            }

            Destroy(BolaDeFogo, 0.075f);
            Explodir = true;

        }



    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ChecarContato.position, RaioColisão);

    }

    public void x(bool vx, int mg)
    {

        spriteFB = GetComponent<SpriteRenderer>();
        spriteFB.flipX = vx;

        mg2 = mg;

    }

}
