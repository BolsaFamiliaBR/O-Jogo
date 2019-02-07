using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    public GameObject poçao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumir()
    {

        poçao.SetActive(false);
        Destroy(poçao, 1f);

    }

}
