using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoFlutuante : MonoBehaviour
{

    public Text texto;

    void Start() { Destroy(gameObject, 1.2f); }

    public void TextoDano(float dano)
    {

        texto.color = Color.white;
        string txt = dano.ToString();

        texto.text = "-" + txt;

    }

    public void TextoPlayer(float dano)
    {

        texto.color = Color.red;
        string txt = dano.ToString();

        texto.text = "-" + txt;

    }

    public void TextoAparar()
    {

        texto.color = Color.yellow;
        texto.text = "Aparou!";

    }

    public void TextoMoeda(string txt)
    {

        texto.color = Color.green;
        texto.text = txt;

    }

    public void TextoVida(string txt)
    {

        texto.color = Color.red;
        texto.text = txt;

    }

    public void TextoVitoria()
    {

        texto.color = Color.yellow;
        texto.text = "Vitoria!";

    }

    public void TextoLevelUp()
    {

        texto.color = Color.green;
        texto.text = "Level Up!";

    }

    public void TextoEsquivar()
    {

        texto.color = Color.yellow;
        texto.text = "Esquivou!";

    }

    public void TextoCritico(float Dano)
    {

        texto.color = Color.red;
        texto.text = "CRITICO! -" + Dano;

    }

}
