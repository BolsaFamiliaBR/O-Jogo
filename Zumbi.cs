using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zumbi : MonoBehaviour
{

    //Variaveis
    public Player player2;
    public ZumbiSpawner spawner;
    public GameObject ChamarTexto;

    bool critico = false;
    bool ItemApareceu = false;
    bool MandouEXP = false;
    bool EstaNoAgro = false;
    bool KnockBackAtivo = false;
    bool EstaNoAgroAtk = false;
    bool EstaMorto = false;
    bool timer = false;

    Transform player;
    Transform zumbi2;
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;
    CapsuleCollider2D colider;

    int level = 0;

    float timer2;
    float tempo;
    float Xzumbi;
    float Xplayer;
    float knock;
    float knockY;

    [Header("Variaveis de movimento")]

    public Transform ChecarPlayer;
    public LayerMask camadaDoPlayer;
    public float velocidade = 5f;
    public float RaioChecarPlayer = 5f;

    [Header("Variaveis de artributos")]

    public float Vida = 100f;
    public float VidaMaxima = 100f;
    public Image barraVida;

    [Header("Variaveis da morte")]

    public GameObject zumbi;
    public GameObject MoedaAparecer;
    public GameObject PoçãoAparecer;

    [Header("Variaveis de ataque")]

    public Transform ChecarPlayerAtk;
    public int dano = 20;
    public float DistanciaAtaque = 0.3f;
    public float TDRAtque;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        zumbi2 = GetComponent<Transform>();
        colider = GetComponent<CapsuleCollider2D>();

        // Vector3 bar = transform.position;

        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {

        if(level > 0)
        {

            dano += 15;
            VidaMaxima += 40;
            Vida += 40;

            level--;

        }

        if (Vida <= 0)
        {
            if (MandouEXP == false) { player2.MatouUmZumbi(); MandouEXP = true; spawner.contagem(); spawner.contagemNeg(); }

            tempo += Time.deltaTime;
            EstaMorto = true;

            if (tempo > 0.3f && timer == false)
            {

                timer = true;
                colider.offset = new Vector2(colider.offset.x, colider.offset.y - -1.12981137f);
                body.position = new Vector2(body.position.x, body.position.y - 0.34f);

            }

            anim.SetTrigger("Morrer");

            if (ItemApareceu == false)
            {

                int r = Random.Range(0, 100);

                if (r <= 5)
                {

                    var poção = Instantiate(PoçãoAparecer, transform.position, Quaternion.identity);
                    ItemApareceu = true;

                }

                else
                {

                    var moedas = Instantiate(MoedaAparecer, transform.position, Quaternion.identity);
                    ItemApareceu = true;

                }
                
            }

            body.velocity = new Vector2(0, 0);
            Destroy(zumbi, 0.8f);

        }

        if (KnockBackAtivo == true)
        {

            Xzumbi = transform.position.x;
            Xplayer = player.transform.position.x;

            if (knock > 9) { knockY = 3; } else { knockY = 2; }

            timer2 += Time.deltaTime;

            if(Xzumbi < Xplayer)
            {

                if (timer2 > 0.2f) { body.velocity = new Vector2(-knock, -knockY); }
                if (timer2 < 0.1f) { body.velocity = new Vector2(-knock, knockY); }

            }

            if(Xzumbi > Xplayer)
            {

                if (timer2 < 0.1f) { body.velocity = new Vector2(knock, knockY); }
                if (timer2 > 0.2f) { body.velocity = new Vector2(knock, -knockY); }

            }

            if (timer2 > 0.3f) { timer2 = 0; KnockBackAtivo = false; }


        }

        barraVida.rectTransform.sizeDelta = new Vector2(Vida / VidaMaxima * 0.306f, 0.033f);

    }

    void FixedUpdate()
    {

        if (EstaMorto == false && KnockBackAtivo == false)
        {

            anim.SetFloat("X", Mathf.Abs(body.velocity.x));

            EstaNoAgro = Physics2D.OverlapCircle(ChecarPlayer.position, RaioChecarPlayer, camadaDoPlayer);
            EstaNoAgroAtk = Physics2D.OverlapCircle(ChecarPlayerAtk.position, DistanciaAtaque, camadaDoPlayer);

            if (EstaNoAgro == true && EstaNoAgroAtk == false)
            {

                Xzumbi = transform.position.x;
                Xplayer = player.transform.position.x;

                if (Xzumbi > Xplayer) //Direita
                {

                    if (sprite.flipX == false) { sprite.flipX = !sprite.flipX; ChecarPlayerAtk.localPosition = new Vector2(-ChecarPlayerAtk.localPosition.x, ChecarPlayerAtk.localPosition.y); }
                    body.velocity = new Vector2(-1 * velocidade, body.velocity.y - body.velocity.y);
                    EstaNoAgro = false;
                }

                if (Xzumbi < Xplayer) // Esquerda
                {

                    if (sprite.flipX == true) { sprite.flipX = !sprite.flipX; ChecarPlayerAtk.localPosition = new Vector2(-ChecarPlayerAtk.localPosition.x, ChecarPlayerAtk.localPosition.y); }
                    body.velocity = new Vector2(1 * velocidade, body.velocity.y - body.velocity.y);
                    EstaNoAgro = false;

                }

            }

            else { body.velocity = new Vector2(0, 0); }

            if (TDRAtque <= 0)
            {

                if (EstaNoAgroAtk == true)
                {

                    anim.SetTrigger("Ataque");
                    player2.Dano(dano, transform.position.x);

                }
                TDRAtque = 1f;

            }

            else { TDRAtque -= Time.deltaTime; }

        }

    }

    public IEnumerator LevarDano(float Dano)
    {

        Vida -= Dano;
        var txtdano = Instantiate(ChamarTexto, transform.position, Quaternion.identity);

        if (critico == true) { txtdano.SendMessage("TextoCritico", Dano); critico = false; }
        else { txtdano.SendMessage("TextoDano", Dano); }

        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;

    }

    public void KnockBack(float Knock)
    {

        knock = Knock;
        KnockBackAtivo = true;

    }

    public void DashPlayer()
    {

        body.constraints = RigidbodyConstraints2D.FreezePositionY;
        colider.isTrigger = true;
        Invoke("DashPlayer2", 0.3f);

    }

    public void DashPlayer2()
    {

        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        colider.isTrigger = false;

    }

    public void SetDano(int lvl)
    {

        level = lvl;

    }

    public void LevarCritico()
    {

        critico = true;

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ChecarPlayer.position, RaioChecarPlayer);
        Gizmos.DrawWireSphere(ChecarPlayerAtk.position, DistanciaAtaque);

    }

}
