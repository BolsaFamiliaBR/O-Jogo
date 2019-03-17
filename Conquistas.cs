using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conquistas : MonoBehaviour
{

    float timer;

    bool isOnScreen = false;

    public Player playerS;
    public Text conquistaTxt;

    [Header("Barras Coluna 1")]

    #region

    public Image BarraZombieSlayer;
    public Image BarraAtacante;
    public Image BarraExpTotal;

    public Text TxtZombieSlayer;
    public Text TxtAtacante;
    public Text TxtExpTotal;

    #endregion

    [Header("Barras Coluna 2")]

    #region

    public Image BarraMortoVivo;
    public Image BarraCapitalista;
    public Image BarraJumper;

    public Text TxtMortoVivo;
    public Text TxtCapitalista;
    public Text TxtJumper;

    #endregion

    [Header("Barras Coluna 3")]

    #region

    public Image BarraDanoSofrido;
    public Image BarraDanoInfringido;
    public Image BarraAcertosCriticos;

    public Text TxtDanoSofrido;
    public Text TxtDanoInfringido;
    public Text TxtAcertosCriticios;

    #endregion

    [Header("Barras Coluna 4")]

    #region

    public Image BarraMatrix;

    public Text TxtMatrix;

    #endregion

    /* Variaveis estaticas */

    #region

    public static float KillCount = 0;
    public static float AtkCount = 0;
    public static float TotalExp = 0;
    public static float DeathCount = 0;
    public static float MoneyCount = 0;
    public static float JumpCount = 0;
    public static float DamageTaken = 0;
    public static float DamageDealer = 0;
    public static float CriticCount = 0;
    public static float DodgeCount = 0;

    float KC = 0;
    float AC = 0;
    float TE = 0;
    float DC = 0;
    float MC = 0; 
    float JC = 0;
    float DT = 0;
    float DD = 0;
    float CC = 0;
    float DoC = 0;

    public float a1;
    public float a2;
    public float a3;
    public float a4;
    public float a5;
    public float a6;
    public float a7;
    public float a8;
    public float a9;
    public float a10;

    #endregion

    /* Variaveis Niveis */

    #region

    public float NPU_KillCount = 0;
    public int Nv_KillCount = 0;

    public float NPU_AtkCount = 0;
    public int Nv_AtkCount = 0;

    public float NPU_TotalExp = 0;
    public int Nv_TotalExp = 0;

    public float NPU_DeathCount = 0;
    public int Nv_DeathCount = 0;

    public float NPU_MoneyCount = 0;
    public int Nv_MoneyCount = 0;

    public float NPU_JumpCount = 0;
    public int Nv_JumpCount = 0;

    public float NPU_DmgTaken = 0;
    public int Nv_DmgTaken = 0;

    public float NPU_DmgDealer = 0;
    public int Nv_DmgDealer = 0;

    public float NPU_CritCount = 0;
    public int Nv_CritCount = 0;

    public float NPU_DodgeCount = 0;
    public int Nv_DodgeCount = 0;

    #endregion

    void Start()
    {

        NPU_KillCount = 25;
        NPU_AtkCount = 25;
        NPU_TotalExp = 350;
        NPU_DeathCount = 5;
        NPU_MoneyCount = 500;
        NPU_JumpCount = 300;
        NPU_DmgTaken = 3000;
        NPU_DmgDealer = 3000;
        NPU_CritCount = 10;
        NPU_DodgeCount = 10;

        KC = KillCount;
        AC = AtkCount;
        TE = TotalExp;
        DC = DeathCount;
        MC = MoneyCount;
        JC = JumpCount;
        DT = DamageTaken;
        DD = DamageDealer;
        CC = CriticCount;
        DoC = DodgeCount;

        conquistaTxt.enabled = false;

    }

    void Update()
    {

        a1 = KC;
        a2 = AC;
        a3 = TE;
        a4 = DC;
        a5 = MC;
        a6 = JC;
        a7 = DT;
        a8 = DD;
        a9 = CC;
        a10 = DoC;

        timer += Time.deltaTime;

        if (timer > 2 && conquistaTxt.enabled == true)
        {

            conquistaTxt.enabled = false;

        }

        /* Upar os niveis */

        #region
 
        if (KC >= NPU_KillCount )
        {

            Nv_KillCount++;
            NPU_KillCount += 25;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Zombie Slayer Nv " + Nv_KillCount;

        } // +30 Dano //

        if (AC >= NPU_AtkCount)
        {

            Nv_AtkCount++;
            AC -= NPU_AtkCount;
            NPU_AtkCount += 25;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Atacante Nv " + Nv_AtkCount;

        } // +5 Dano //

        if (TE >= NPU_TotalExp)
        {

            Nv_TotalExp++;
            NPU_TotalExp += 350;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Exp total Nv " + Nv_TotalExp;

        } // +2 Pontos de upgrade inicial

        if (DC >= NPU_DeathCount)
        {

            Nv_DeathCount++;
            NPU_DeathCount += 5;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Morto Vivo Nv " + Nv_DeathCount;

        } // +20 Armadura //

        if (MC >= NPU_MoneyCount)
        {

            Nv_MoneyCount++;
            NPU_MoneyCount += 500;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Capitalista Nv " + Nv_MoneyCount;

        } // +50 Ouro no inicio //

        if (JC >= NPU_JumpCount)
        {

            Nv_JumpCount++;
            NPU_JumpCount += 300;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Jumper Nv " + Nv_JumpCount;

        } // +50 Pulo //

        if (DT >= NPU_DmgTaken)
        {

            Nv_DmgTaken++;
            DT -= NPU_DmgTaken;
            NPU_DmgTaken += 3000;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Dano Sofrido Nv " + Nv_DmgTaken;

        } // +20 Armadura //

        if (DD >= NPU_DmgDealer)
        {

            DD -= NPU_DmgDealer;
            Nv_DmgDealer++;
            NPU_DmgDealer += 3000;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Dano Infringido Nv " + Nv_DmgDealer;

        } // +20 Dano  //

        if (CC >= NPU_CritCount)
        {

            Nv_CritCount++;
            NPU_CritCount += 25;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Acertos Criticos Nv " + Nv_CritCount;

        } // Dano Adicional +20

        if (DoC >= NPU_DodgeCount)
        {

            Nv_DodgeCount++;
            NPU_DodgeCount += 10;
            timer = 0;

            conquistaTxt.enabled = true;
            conquistaTxt.text = "Conquista Desbloqueada \n Matrix Nv " + Nv_DodgeCount;

        } // 10% Do dano desviado volta em forma de cura

        #endregion

        /* Atualizar informações das barras */

        #region

        BarraZombieSlayer.rectTransform.sizeDelta = new Vector2(a1 / NPU_KillCount * 120.88f, 8f);

        BarraAtacante.rectTransform.sizeDelta = new Vector2(a2 / NPU_AtkCount * 120.88f, 8f);
        BarraExpTotal.rectTransform.sizeDelta = new Vector2(a3 / NPU_TotalExp * 120.88f, 8f);

        BarraMortoVivo.rectTransform.sizeDelta = new Vector2(a4 / NPU_DeathCount * 120.88f, 8f);
        BarraCapitalista.rectTransform.sizeDelta = new Vector2(a5 / NPU_MoneyCount * 120.88f, 8f);
        BarraJumper.rectTransform.sizeDelta = new Vector2(a6 / NPU_JumpCount * 120.88f, 8f);

        BarraDanoSofrido.rectTransform.sizeDelta = new Vector2(a7 / NPU_DmgDealer * 120.88f, 8f);
        BarraDanoInfringido.rectTransform.sizeDelta = new Vector2(a8 / NPU_DmgTaken * 120.88f, 8f);
        BarraAcertosCriticos.rectTransform.sizeDelta = new Vector2(a9 / NPU_CritCount * 120.88f, 8f);

        BarraMatrix.rectTransform.sizeDelta = new Vector2(a10 / NPU_DodgeCount * 120.88f, 8f);

        #endregion

        /* Atualizar Txt's na tela inicial */

        #region

        TxtZombieSlayer.text = "Zombie Slayer Nv " + Nv_KillCount;
        TxtAtacante.text = "Atacante Nv " + Nv_AtkCount;
        TxtExpTotal.text = "Exp Total Nv " + Nv_TotalExp;
        TxtMortoVivo.text = "Morto Vivo Nv " + Nv_TotalExp;
        TxtCapitalista.text = "Capitalista Nv " + Nv_MoneyCount;
        TxtJumper.text = "Jumper Nv " + Nv_JumpCount;
        TxtDanoSofrido.text = "Dano Sofrido Nv " + Nv_DmgTaken;
        TxtDanoInfringido.text = "Dano Infringido Nv " + Nv_DmgDealer;
        TxtAcertosCriticios.text = "Acertos Criticos Nv " + Nv_CritCount;
        TxtMatrix.text = "Matrix Nv " + Nv_DodgeCount;

        #endregion

        playerS.AtualizarBuffs();

    }

    public void ZombieKill()
    {

        KillCount++;
        KC++;

    }

    public void ExpGain(int xp)
    {

        TotalExp += xp;
        TE += xp;

    }

    public void AttackCount()
    {

        AtkCount++;
        AC++;


    }

    public void DmgCount(float dmg)
    {

        DamageDealer += dmg;
        DD += dmg;

    }

    public void Death()
    {

        DeathCount++;
        DC++;

    }

    public void Money(int m)
    {

        MoneyCount += m;
        MC += m;

    }

    public void Jump()
    {

        JumpCount++;
        JC++;

    }

    public void DmgTaken(int dmg)
    {

        DamageTaken += dmg;
        DT += dmg;


    }

    public void Critic()
    {

        CriticCount++;
        CC++;

    }

    public void Dodge()
    {

        DodgeCount++;
        DoC++;

    }

}
