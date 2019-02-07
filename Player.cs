using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //Variaveis

    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;
    Animator anim2;

    string ZumbisNoMapaString;

    int horda = 1;
    int ProteçãoContraAzar = 0;
    int preçoAcertoCr = 50;
    int preçoArmadura = 50;
    int preçoEsquiva = 50;
    int preçoMagico = 50;
    int preçoPulo = 50;
    int pulo = 0;
    int danoMagico = 0;
    int esquiva = 0;
    int armadura = 0;
    int critico = 0;
    int ZumbisNoMapa = 0;
    int PontosUpgrade = 0;
    int vidaMaxima = 100;
    int manaMaxima = 100;
    int UpMana = 0;
    int UpVida = 0;
    int UpAtaque = 0;

    float width;
    float height;
    float timer;
    float timer2;
    float timer3;
    float timer4;
    float timerRegen;
    float timerRegen2;
    float timer_Horda;
    float XZumbi;
    float DefesaCD = 0f;
    float PuloExtra = 1f;

    bool HUDJaSumiu = false;
    bool JogoJaIniciou = false;
    bool JogoIniciou = false;
    bool DarCritico = false;
    bool DeuCritico = false;
    bool Esquivou = false;
    bool EstaNoCast = false;
    bool KnockBack = false;
    bool CDAtaque = false;
    bool CDSpellB = false;
    bool CDAparar = false;
    bool LevouDano = false;
    bool EstaAtacando = false;
    bool EstaNoChao = false;
    bool EstaNoUpgrade = false;
    bool EstaPulando = false;
    bool EstaDefendendo = false;
    bool DesativarGameOver = true;
    bool EstaMorto = false;
    bool PegarMoeda = false;
    bool PegarPoção = false;
    bool HordaNoHUD = false;
    bool HordaHUDSaindo = false;

    //Variaveis publicas

    [Header(" --------> Variaveis de Loja <--------")]

    public Text PreçoArmadura;
    public Text PreçoCritico;
    public Text PreçoEsquiva;
    public Text PreçoDanoMagico;
    public Text PreçoForçaPulo;

    public Text DescriçãoArmadura;
    public Text DescriçãoCritico;
    public Text DescriçãoEsquiva;
    public Text DescriçãoDanoMagico;
    public Text DescriçãoForçaPulo;

    public Text StatusDinheiro;
    public Text StatusArmadura;
    public Text StatusCritico;
    public Text StatusEsquiva;
    public Text StatusDanoMagico;
    public Text StatusForçaPulo;

    [Header(" --------> Variaveis de Upgrade <--------")]

    public Image Fundo;

    public ZumbiSpawner spawner;

    public RectTransform HUDTamanho;

    public Canvas HUDUpgrade;
    public Canvas HUDInicio;

    public Text PntsTxt;
    public Text VidaTxt;
    public Text ManaTxt;
    public Text DanoTxt;
    public Text TextoAtaque;
    public Text TextoMana;
    public Text TextoVida;

    public Button BVida;
    public Button BMana;
    public Button BAtaque;

    [Header(" --------> Variaveis de movimento <--------")]

    public float velocidade = 7f;
    public float ForçaPulo = 200f;
    public float RaioChecarSolo = 0.2f;
    public float RaioChecarInimigo2 = 5f;
    public Transform ChecarSolo;
    public GameObject Vento;
    public LayerMask CamadaDoChao;
    public Transform ChecarInimigoDash;

    [Header("--------> Variaveis de ataque <--------")]

    public FireBall BolaDeFogoScript;
    public GameObject txtDano;
    public GameObject FireBall;
    public Transform ChecarInimigo;
    public LayerMask camadaDoInimigo;
    public float KnockBase = 3f;
    public float RaioChecarInimigo = 0.2f;
    public float TempoDeRecargaAtaque = 0f;
    public float TempoDeRecarcaFireBall = 0f;
    public float DanoBase = 25f;

    [Header("--------> Variaveis de Diversos <--------")]

    public Animator anim3;
    public Animator anim4;
    public Animator anim5;

    public Text NumeroHorda;
    public Text DescHorda;
    public Text ZumbisHUD;
    public Text LevelHUD;
    public Text DinheiroHUD;

    public ZumbiSpawner Spawner;
    public Barra barra;

    public GameObject jogador;
    public GameObject GameOver;

    public Image FundoInicio;
    public Image FundoMeio;
    public Image CDataque;
    public Image CDaparar;
    public Image CDFireBa;

    public Transform ChecarMoeda;
    public Transform ChecarPoção;

    public LayerMask CamadaPoção;
    public LayerMask CamadaMoeda;

    public float RaioPoção = 2f;
    public float RaioMoeda = 2f;

    [Header("--------> Variaveis de caracteristicas <--------")]

    public int Level = 1;
    public int vida = 100;
    public int mana = 100;
    public int dinheiro = 1000;
    public int experiencia = 90;

    // Start is called before the first frame update
    void Start()
    {

        height = HUDTamanho.rect.height;
        width = HUDTamanho.rect.width;

        Fundo.rectTransform.sizeDelta = new Vector2(width, height); 
        GameOver.SetActive(false);

        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim2 = Fundo.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        timer4 += Time.deltaTime;

        if (timer4 >= 1 && JogoIniciou == true && JogoJaIniciou == false)
        {

            anim4.SetTrigger("Sair");
            Spawner.ComeçarJogo();
            JogoJaIniciou = true;

        }

        if (timer4 >= 3 && JogoIniciou == true)
        {

            if (HUDJaSumiu == false)
            {

                HUDInicio.enabled = !HUDInicio.enabled;
                HUDJaSumiu = true;
                HordaNoHUD = true;

                anim3.SetTrigger("Aparecer");
                Invoke("ResetHordaHUD", 3f);

            }

        }

        if (HordaHUDSaindo == true && timer_Horda >= 3 && HordaNoHUD == true)
        {

            anim3.SetTrigger("Parar");
            HordaHUDSaindo = false;
            HordaNoHUD = false;

        }

        else { timer_Horda += Time.deltaTime; }

        if(body.velocity.x != 0 && body.velocity.y == 0) { timer3 += Time.deltaTime; }
  
        else { timer3 = 0; }

        if (vida < 0) { vida = 0; }
        if (vida > vidaMaxima) { vida = vidaMaxima; }

        if (CDAtaque == true) { CDataque.fillAmount += 1 / TempoDeRecargaAtaque * Time.deltaTime; }
        if (CDAparar == true) { CDaparar.fillAmount += 1 / DefesaCD * Time.deltaTime; }
        if (CDSpellB == true) { CDFireBa.fillAmount += 1 / TempoDeRecarcaFireBall * Time.deltaTime / 2; }

        if (CDaparar.fillAmount >= 1) { CDAparar = false; DefesaCD = 0f; CDaparar.fillAmount = 0; }
        if (CDataque.fillAmount >= 1) { CDAtaque = false; TempoDeRecargaAtaque = 0f; CDataque.fillAmount = 0; }
        if (CDFireBa.fillAmount >= 1) { CDSpellB = false; TempoDeRecarcaFireBall = 0f; CDFireBa.fillAmount = 0; }

        StatusDinheiro.text = "Dinheiro:             " + dinheiro;

        if (EstaMorto == false && EstaNoUpgrade == false && HordaNoHUD == false && JogoIniciou == true)
        {

            if (EstaNoCast == false && EstaAtacando == false)
            {

                if(Input.GetButtonDown("Dash") && timer3 >= 0.5f)
                {

                    EstaAtacando = true;

                    anim.ResetTrigger("Magia");
                    anim.ResetTrigger("Morrer");
                    anim.ResetTrigger("Ataque");
                    anim.ResetTrigger("Aparar");

                    anim.SetTrigger("Dash");

                    if(sprite.flipX != true) { var vento = Instantiate(Vento, new Vector2(transform.position.x + 0.5f, transform.position.y - 0.8f), Quaternion.identity); }

                    else { var vento = Instantiate(Vento, new Vector2(transform.position.x - 0.5f, transform.position.y - 0.8f), Quaternion.identity);}

                    Collider2D[] InimigosPorPerto = Physics2D.OverlapCircleAll(ChecarInimigoDash.position, RaioChecarInimigo2, camadaDoInimigo);
                    for (int i = 0; i < InimigosPorPerto.Length; i++)
                    {

                        InimigosPorPerto[i].SendMessage("DashPlayer");
                        Debug.Log(InimigosPorPerto[i].name);

                    }

                    timer3 = 0;
                    Invoke("ResetBool", 0.7f);

                }

                if (Input.GetButtonDown("Jump") && PuloExtra > 0)
                {

                    EstaPulando = true;
                    PuloExtra--;

                }

                if (Input.GetButtonDown("Defender") && EstaDefendendo == false)
                {

                    if (DefesaCD <= 0) { EstaDefendendo = true; anim.SetTrigger("Aparar"); DefesaCD = 1f; CDAparar = true; }

                }

                if (Input.GetButtonDown("Spell") && TempoDeRecarcaFireBall <= 0 && mana > 24)
                {

                    anim.ResetTrigger("Dash");
                    anim.ResetTrigger("Morrer");
                    anim.ResetTrigger("Ataque");
                    anim.ResetTrigger("Aparar");

                    body.velocity = new Vector2(0, 0);
                    timer2 = 0;
                    EstaNoCast = true;
                    anim.SetTrigger("Magia");
                    Invoke("BolaDeFogo", 0.5f);
                    mana -= 25;
                    TempoDeRecarcaFireBall = 1f;
                    CDSpellB = true;

                }

                if (TempoDeRecargaAtaque <= 0)
                {

                    if (Input.GetButtonDown("Fire1"))
                    {

                        EstaAtacando = true;
                        CDAtaque = true;
                        anim.SetTrigger("Ataque");
                        Invoke("ResetBool", 0.3f);
                        TempoDeRecargaAtaque = 0.5f;

                    }

                }

            }

            if (DesativarGameOver == true) { GameOver.SetActive(false); DesativarGameOver = false; }

            if (PegarMoeda == true)
            {

                Collider2D[] moedasAtingidas = Physics2D.OverlapCircleAll(ChecarMoeda.position, RaioMoeda, CamadaMoeda);
                for (int i = 0; i < moedasAtingidas.Length; i++)
                {

                    moedasAtingidas[i].SendMessage("sumir");
                    Debug.Log(moedasAtingidas[i].name);
                    dinheiro += 5;
                    var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
                    txtdano.SendMessage("TextoMoeda", "+5");
                    Debug.Log(dinheiro);

                }

            }

            if (EstaNoChao) { PuloExtra = 1; }

            if (LevouDano == true) { sprite.color = Color.red; Invoke("Piscar", 0.3f); }

            if (vida <= 0) { anim.SetTrigger("Morrer"); Invoke("Morrer", 0.6667f); }

            if (KnockBack == true)
            {

                timer += Time.deltaTime;

                if (XZumbi > transform.position.x)
                {

                    if (timer < 0.1f) { body.velocity = new Vector2(-3, 1); }
                    if (timer > 0.2f) { body.velocity = new Vector2(-3, -1); }

                }

                if (XZumbi < transform.position.x)
                {

                    if (timer < 0.1f) { body.velocity = new Vector2(3, 1); }
                    if (timer > 0.2f) { body.velocity = new Vector2(3, -1); }

                }

                if (timer > 0.3f) { timer = 0; KnockBack = false; }

            }

            if (mana < manaMaxima && timerRegen > 1)
            {

                mana++;
                timerRegen = 0;

            }

            if (vida < vidaMaxima && timerRegen2 > 1)
            {

                vida++;
                timerRegen2 = 0;

            }

            if(EstaNoCast == true)
            {

                timer2 += Time.deltaTime;

                if(timer2 > 1)
                {

                    EstaNoCast = false;
                    timer2 = 0;

                }

            }

            if(PegarPoção == true)
            {

                if (vida != vidaMaxima)
                {

                    Collider2D[] PoçaoAtingida = Physics2D.OverlapCircleAll(ChecarPoção.position, RaioPoção, CamadaPoção);
                    for (int i = 0; i < PoçaoAtingida.Length; i++)
                    {

                        PoçaoAtingida[i].SendMessage("sumir");
                        Debug.Log(PoçaoAtingida[i].name);
                        vida += 30;
                        var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
                        txtdano.SendMessage("TextoVida", "+30");

                    }

                }

            }

            timerRegen += Time.deltaTime;
            timerRegen2 += Time.deltaTime;

            anim.SetFloat("X", Mathf.Abs(body.velocity.x));
            anim.SetFloat("Y", Mathf.Abs(body.velocity.y));

            PegarPoção = Physics2D.OverlapCircle(ChecarPoção.position, RaioPoção, CamadaPoção);
            EstaNoChao = Physics2D.OverlapCircle(ChecarSolo.position, RaioChecarSolo, CamadaDoChao);
            PegarMoeda = Physics2D.OverlapCircle(ChecarMoeda.position, RaioMoeda, CamadaMoeda);

            ZumbisNoMapaString = ZumbisNoMapa.ToString();
            ZumbisHUD.text = ZumbisNoMapaString;

            barra.atualizarVida(vida);
            barra.atualizarMana(mana);
            barra.atualizarExp(experiencia);
            fDinheiroHUD();
            LevelUP();


        }

        else if (EstaMorto == true) { GameOver2(); }

    }

    private void FixedUpdate()
    {

        if (KnockBack == false && EstaMorto == false && EstaNoCast == false && EstaNoUpgrade == false && HordaNoHUD == false && JogoIniciou == true)
        {

            float move = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(move * velocidade, body.velocity.y);

            if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false)) { Flip(); }

            if (body.velocity.y > 0f && !Input.GetButton("Jump")) { body.velocity += Vector2.up * -0.8f; }

            if (EstaPulando)
            {

                body.velocity = new Vector2(body.velocity.x, 0f);
                body.AddForce(new Vector2(0f, ForçaPulo));
                EstaPulando = false;

            }

        }

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ChecarSolo.position, RaioChecarSolo);
        Gizmos.DrawWireSphere(ChecarInimigo.position, RaioChecarInimigo);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(ChecarMoeda.position, RaioMoeda);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ChecarPoção.position, RaioPoção);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ChecarInimigoDash.position, RaioChecarInimigo2);

    }

    void ResetBool()
    {

        EstaAtacando = false;

    }

    void ResetHordaHUD()
    {

        timer_Horda = 0;
        anim3.SetTrigger("Sair");
        HordaHUDSaindo = true;

    }

    void GameOver2()
    {

        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    }

    void Piscar()
    {

        sprite.color = Color.white;

        LevouDano = false;

    }

    void Flip()
    {

        sprite.flipX = !sprite.flipX;
        ChecarInimigo.localPosition = new Vector2(-ChecarInimigo.localPosition.x, ChecarInimigo.localPosition.y);

    }

    void Morrer()
    {

        gameObject.layer = 0;
        gameObject.GetComponent<Renderer>().enabled = false;
        GameOver.SetActive(true);
        EstaMorto = true;

    }

    void fDinheiroHUD()
    {

        string a = dinheiro.ToString();

        if (dinheiro < 10 && dinheiro >= 0) { DinheiroHUD.text = "0000" + a; }
        if (dinheiro < 100 && dinheiro >= 10) { DinheiroHUD.text = "000" + a; }
        if (dinheiro < 1000 && dinheiro >= 100) { DinheiroHUD.text = "00" + a; }
        if (dinheiro < 10000 && dinheiro >= 1000) { DinheiroHUD.text = "0" + a; }

        if (dinheiro >= 10000) { DinheiroHUD.text = a; }

    }

    void BolaDeFogo()
    {

        BolaDeFogoScript.x(sprite.flipX, danoMagico);
        var SumonarFB = Instantiate(FireBall, new Vector2(transform.position.x + 0.2f, transform.position.y - 0.4f), Quaternion.identity);

    }

    void LevelUP()
    {

        int NecessidadeParaUpar = 0;
        NecessidadeParaUpar = 100 * Level;

        barra.atualizarExp2(NecessidadeParaUpar);

        if(experiencia >= NecessidadeParaUpar)
        {

            PontosUpgrade += 3;
            Level++;
            experiencia = 0;

            vidaMaxima += 60;
            manaMaxima += 60;
            DanoBase += 10;

            barra.atualizarVida2(vidaMaxima);
            barra.atualizarMana2(manaMaxima);

            vida = vidaMaxima;
            mana = manaMaxima;

            var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
            txtdano.SendMessage("TextoLevelUp");

            string a = Level.ToString();
            LevelHUD.text = a;
            
        }

    }

    void SetarTela()
    {

        Fundo.rectTransform.position = new Vector2(0, Fundo.rectTransform.position.y);
        anim2.SetTrigger("Parar");
        anim.SetBool("Vitoria", false);

    }

    public void Aparar()
    {

        EstaDefendendo = false;

    }

    public void Atacar()
    {

        Collider2D[] InimigosAtacados = Physics2D.OverlapCircleAll(ChecarInimigo.position, RaioChecarInimigo, camadaDoInimigo);
        for (int i = 0; i < InimigosAtacados.Length; i++)
        {

            float knockTotal = 0;
            float danoTotal = 0;
            float Minimo = critico;

            if (critico < 90 && Minimo < 100)
            {

                Minimo += ProteçãoContraAzar;

                if (ProteçãoContraAzar > 25)
                {

                    DarCritico = true;

                }

            }

            int a = Random.Range(critico, 100);

            if (DarCritico == true) { a = 100; }

            if (a == 100 && critico != 0)
            {

                danoTotal = DanoBase + 50;
                knockTotal = KnockBase + 4;
                ProteçãoContraAzar = 0;
                DarCritico = false;
                DeuCritico = true;

            }

            else
            {

                danoTotal = DanoBase;
                knockTotal = KnockBase;

                Debug.Log(ProteçãoContraAzar);

            }

            if (DeuCritico == true)
            {

                InimigosAtacados[i].SendMessage("LevarCritico");
                DeuCritico = false;

            }

            else { if (critico != 0) { ProteçãoContraAzar++; }  }

            InimigosAtacados[i].SendMessage("LevarDano", danoTotal);
            InimigosAtacados[i].SendMessage("KnockBack", knockTotal);
            Debug.Log(InimigosAtacados[i].name);

        }

    }

    public void Dano(int dano, float xzumbi)
    {

        if (EstaDefendendo == true)
        {

            EstaDefendendo = false;
            LevouDano = false;
            var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
            txtdano.SendMessage("TextoAparar");

        }

        else
        {

            int esquivarA = Random.Range(0, 30);

            for(int x = esquiva; x > 0; x--)
            {

                int esquivarB = Random.Range(0, 100);

                if(esquivarA == esquivarB)
                {

                    Esquivou = true;
                    x = 0; 

                }
                
            }

            if (Esquivou == false)
            {

                XZumbi = xzumbi;

                if (armadura != 0) { dano = dano - armadura * Random.Range(1, 2); }

                vida -= dano;

                timer = 0;

                var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
                txtdano.SendMessage("TextoPlayer", dano);
                LevouDano = true;
                EstaDefendendo = false;
                KnockBack = true;

            }

            else if (Esquivou == true)
            {

                var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
                txtdano.SendMessage("TextoEsquivar");
                Esquivou = false;

            }

        }

    }

    public void MatouUmZumbi()
    {

        experiencia += 20;

    }

    public void UpgradeAtaque()
    {

        if (PontosUpgrade > 0)
        {

            PontosUpgrade--;
            UpAtaque++;
            TextoAtaque.text = UpAtaque + "/10";
            DanoBase += 15;
            DanoTxt.text = "Dano: " + DanoBase;
            PntsTxt.text = "Pontos Para Gastar: " + PontosUpgrade;

        }

        if (UpAtaque == 10)
        {

            BAtaque.interactable = false;

        }

    }

    public void UpgradeMana()
    {

        if (PontosUpgrade > 0)
        {

            PontosUpgrade--;
            UpMana++;
            TextoMana.text = UpMana + "/10";
            manaMaxima += 30; mana += 30;
            ManaTxt.text = "Mana: " + mana + "/" + manaMaxima;
            PntsTxt.text = "Pontos Para Gastar: " + PontosUpgrade;

        }

        if (UpMana == 10)
        {

            BMana.interactable = false;

        }


    }

    public void UpgradeVida()
    {

        if (PontosUpgrade > 0)
        {

            PontosUpgrade--;
            UpVida++;
            TextoVida.text = UpVida + "/10";
            vidaMaxima += 30; vida += 30;
            VidaTxt.text = "Vida: " + vida + "/" + vidaMaxima;
            PntsTxt.text = "Pontos Para Gastar: " + PontosUpgrade;

        }

        if(UpVida == 10)
        {

            BVida.interactable = false;

        }
        

    }

    public void voltarAoJogo()
    {

        horda++;

        if (horda < 10) { NumeroHorda.text = "~ Horda #0" + horda + " ~"; }

        else { NumeroHorda.text = "~ Horda #" + horda + " ~"; }

        HordaNoHUD = true;
        EstaNoUpgrade = false;

        anim3.SetTrigger("Aparecer");
        Invoke("ResetHordaHUD", 3f);

    }

    public void TelaUpgrade()
    {

        EstaNoUpgrade = true;

        var txtdano = Instantiate(txtDano, transform.position, Quaternion.identity);
        txtdano.SendMessage("TextoVitoria");

        anim.SetBool("Vitoria", true);
        body.velocity = new Vector2(0, 0);

        anim2.SetTrigger("Mover");
        Invoke("SetarTela", 2f);

        PntsTxt.text = "Pontos Para Gastar: " + PontosUpgrade;
        VidaTxt.text = "Vida: " + vida + "/" + vidaMaxima;
        ManaTxt.text = "Mana: " + mana + "/" + manaMaxima;
        DanoTxt.text = "Dano: " + DanoBase;

    }

    public void contagem(int cont)
    {

        ZumbisNoMapa = cont;

    }

    public void Armadura()
    {

        if (dinheiro >= preçoArmadura)
        {

            armadura++;
            dinheiro -= preçoArmadura;

            preçoArmadura = 50 * armadura + 10;

            string a = preçoArmadura.ToString();

            PreçoArmadura.text = a;
            DescriçãoArmadura.text = "Armadura (Nv: " + armadura +")";
            StatusDinheiro.text = "Dinheiro:             " + dinheiro;
            StatusArmadura.text = "Armadura:           " + armadura;

        }

    }

    public void Critico()
    {

        if (dinheiro >= preçoAcertoCr)
        {

            critico++;
            dinheiro -= preçoAcertoCr;

            preçoAcertoCr = 50 * critico + 10;

            string a = preçoAcertoCr.ToString();

            PreçoCritico.text = a;
            DescriçãoCritico.text = "Acerto Critico (Nv: " + critico + ")";
            StatusDinheiro.text = "Dinheiro:             " + dinheiro;
            StatusCritico.text = "Acerto Critico:    " + critico + "%";

        }

    }

    public void Esquiva()
    {

        if (dinheiro >= preçoEsquiva)
        {

            esquiva++;
            dinheiro -= preçoEsquiva;

            preçoEsquiva = 50 * esquiva + 10;

            string a = preçoEsquiva.ToString();

            PreçoEsquiva.text = a;
            DescriçãoEsquiva.text = "Esquiva (Nv: " + esquiva + ")";
            StatusDinheiro.text = "Dinheiro:             " + dinheiro;
            StatusEsquiva.text = "Esquiva:               " + esquiva + "%";

        }


    }

    public void Magico()
    {

        if (dinheiro >= preçoMagico)
        {

            danoMagico++;
            dinheiro -= preçoMagico;

            preçoMagico = 50 * danoMagico + 10;

            string a = preçoMagico.ToString();

            PreçoDanoMagico.text = a;
            DescriçãoDanoMagico.text = "Dano Magico (Nv: " + danoMagico + ")";
            StatusDinheiro.text = "Dinheiro:             " + dinheiro;
            StatusDanoMagico.text = "Dano Magico:       " + danoMagico;

        }

    }

    public void Pulo()
    {

        if (dinheiro >= preçoPulo)
        {

            pulo++;
            dinheiro -= preçoPulo;

            preçoPulo = 50 * pulo + 10;

            string a = preçoPulo.ToString();

            PreçoForçaPulo.text = a;
            DescriçãoForçaPulo.text = "Força do Pulo (Nv: " + pulo + ")";
            StatusDinheiro.text = "Dinheiro:             " + dinheiro;
            StatusForçaPulo.text = "Força do pulo:      " + pulo;

            ForçaPulo += 22.5f;

        }

    }

    public void IniciarJogo()
    {

        JogoIniciou = true;
        anim5.SetTrigger("Click");
        timer4 = 0;

    }
    
    public void FimDeJogo()
    {

        Debug.Log("2");
        NumeroHorda.text = "Vitoria!";
        DescHorda.text = "Voce derrotou todas as hordas";
        anim3.SetTrigger("Aparecer");
        Invoke("ResetHordaHUD", 3f);

    }

}
