using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZumbiSpawner : MonoBehaviour
{

    float timer2 = 0;

    int level = 1;
    int ZumbisNoMapa = 0;
    int pontos;
    int Contagem = 0;
    int ContagemSpawn = 0;

    public Button Loja;
    public Button Conti;

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

    bool TimerReset = false;
    bool LojaAtiva = false;
    bool BotaoAtivo = true;
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

        timer2 += Time.deltaTime;

        if (JogoComeçou == true)
        {

            if (BotaoAtivo == true && LojaAtiva == false)
            {

                Loja.interactable = false;
                Conti.interactable = false;

            }

            if (level == 10)
            {

                if (HudAtiva == true)
                {

                    Contagem = 0;
                    hud.enabled = !hud.enabled;
                    HudAtiva = false;
                    playerScript.FimDeJogo();
                    

                }

            }

            if (Contagem >= 10 && level != 10)
            {

                if (HudAtiva == true)
                {

                    if (TimerReset == false) { timer2 = 0; TimerReset = true; level++; }

                    if (level != 10 && timer2 > 3)
                    {

                        HudAtiva = false;
                        playerScript.TelaUpgrade();

                        LojaAtiva = true;
                        TimerReset = false;
                        Conti.interactable = true;
                        Loja.interactable = true;

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

                    if (localSpawn.x > XPlayerMe && localSpawn.x < XPlayerMa) {}

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
        LojaAtiva = false;

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
