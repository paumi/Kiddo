using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudo : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        Destroy(gameObject); 
    }


}
