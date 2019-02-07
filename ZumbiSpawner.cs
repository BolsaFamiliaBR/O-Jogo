using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZumbiSpawner : MonoBehaviour
{

    int level = 1;
    int ZumbisNoMapa = 0;
    int pontos;
    int Contagem = 0;
    int ContagemSpawn = 0;

    public Zumbi zumbiScript;
    public Image fundo;
    public Image fundoLoja;
    public Player playerScript;
    public Canvas hud;
    public Canvas hud2;
    public Text PontosPGastar;
    public GameObject player;
    public GameObject zumbi;

    Transform playerT;
    Animator animLoja;
    Animator anim;

    bool HudAtiva = true;
    bool JogoComeçou = false;

    public float timer;

    float XPlayer;
    float XPlayerMa;
    float XPlayerMe;

    void Start()
    {

        animLoja = fundoLoja.GetComponent<Animator>();
        anim = fundo.GetComponent<Animator>();
        playerT = player.GetComponent<Transform>();
        hud.enabled = true;

    }

    void Update()
    {

        if (JogoComeçou == true)
        {

            if (level == 5)
            {

                if (HudAtiva == true)
                {

                    Contagem = 0;
                    Debug.Log("1");
                    hud.enabled = !hud.enabled;
                    HudAtiva = false;
                    playerScript.FimDeJogo();
                    

                }

            }

            if (Contagem >= 10 && level != 5)
            {

                if (HudAtiva == true)
                {

                    level++;

                    if (level != 5)
                    {

                        HudAtiva = false;
                        playerScript.TelaUpgrade();

                    }

                }

            }

            else
            {

                XPlayer = playerT.position.x;

                XPlayerMa = XPlayer + 5;
                XPlayerMe = XPlayer - 5;

                timer += Time.deltaTime;

                if (timer >= 5 && ContagemSpawn != 10)
                {

                    Vector2 localSpawn = new Vector2(Random.Range(-10.0f, 20.0f), -3f);

                    if (localSpawn.x > XPlayerMe && localSpawn.x < XPlayerMa) { Debug.Log("Ta no range"); }

                    else
                    {

                        ContagemSpawn++;
                        Instantiate(zumbi, localSpawn, Quaternion.identity);
                        ZumbisNoMapa++;
                        timer = 0;

                    }

                }

            }

        }

        playerScript.contagem(ZumbisNoMapa);

    }

    void continuar()
    {
    
        zumbiScript.SetDano(level);
        anim.SetTrigger("PararFora");

    }

    public void contagem() { Contagem++; }

    public void BotaoContinuar()
    {

        Contagem = 0;
        ContagemSpawn = 0;
        timer = 0;

        anim.SetTrigger("MoverFora");
        Invoke("continuar", 2f);

        HudAtiva = true;

        playerScript.voltarAoJogo();

    }

    public void BotaoLoja()
    {

        animLoja.SetTrigger("Baixo");
        anim.SetTrigger("Baixo");

    }

    public void BotaoVoltar()
    {

        animLoja.SetTrigger("Cima");
        anim.SetTrigger("Cima");

    }

    public void contagemNeg()
    {

        ZumbisNoMapa -= 1;

    }

    public void ComeçarJogo()
    {

        JogoComeçou = true;
        hud.enabled = true;

    }

}
