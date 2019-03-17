using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{

    public Image barraVidaUI;
    public Image barraManaUI;
    public Image barraExpUI;

    public float ManaMaxima = 100f;
    public float ManaAtual = 0f;

    public float XPMaximo = 100f;
    public float XPAtual = 0f;

    public float vidaMaxima = 100f;
    public float vidaAtual;

    // Start is called before the first frame update
    void Start()
    {

        vidaAtual = vidaMaxima;
        ManaAtual = ManaMaxima;

    }

    // Update is called once per frame
    void Update()
    {

        if (ManaAtual < 1) { ManaAtual = 0; }
        if (vidaAtual < 1) { vidaAtual = 0; }

        if (ManaAtual > ManaMaxima) { ManaAtual = ManaMaxima; }
        if (vidaAtual > vidaMaxima) { vidaAtual = vidaMaxima; }

        barraManaUI.rectTransform.sizeDelta = new Vector2(ManaAtual / ManaMaxima * 170f, 10f);
        barraVidaUI.rectTransform.sizeDelta = new Vector2(vidaAtual / vidaMaxima * 209.7f, 12f);
        barraExpUI.rectTransform.sizeDelta = new Vector2(XPAtual / XPMaximo * 131.7f, 8);
        
    }

    public void atualizarVida(int vida) { vidaAtual = vida; }
    public void atualizarVida2(int vida2) { vidaMaxima = vida2; }

    public void atualizarMana(int mana) { ManaAtual = mana; }
    public void atualizarMana2(int mana2) { ManaMaxima = mana2; }

    public void atualizarExp(int exp) { XPAtual = exp; }
    public void atualizarExp2(int exp2) { XPMaximo = exp2; }

}
