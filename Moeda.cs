using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{

    public GameObject moeda;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumir()
    {

        moeda.SetActive(false);
        Destroy(moeda, 1f);

    }
}
