using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    float XDireita = 16;
    float XEsquerda = -6f;
    float YLimite = -2.41f;

    public float speed = 0.15f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;

        if(Screen.width >= 1920)
        {

            transform.localScale = new Vector3(0.45f, 0.45f, transform.localScale.z);


        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {

            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0,0,-10);

        }

        if (transform.position.x > XDireita)
        {

            transform.position = new Vector3(XDireita, transform.position.y, transform.position.z);

        }

        if (transform.position.x < XEsquerda)
        {

            transform.position = new Vector3(XEsquerda, transform.position.y, transform.position.z);

        }

        if (transform.position.y > YLimite)
        {

            transform.position = new Vector3(transform.position.x, YLimite, transform.position.z);


        }
        
    }


}
