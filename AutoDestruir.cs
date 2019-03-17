using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruir : MonoBehaviour
{ 

    public GameObject vento;

    // Start is called before the first frame update
    void Start()
    {

        if (vento != null)
        {
            Destroy(vento, 0.6f);
        }

    }

}
