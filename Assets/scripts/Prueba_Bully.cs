using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_Bully : MonoBehaviour {

    // Use this for initialization
    public GameObject smell;
    float cont = 0;

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if(cont <= 0f)
        {
            Instantiate(smell, transform);
        }
        cont += 1;
        
	}
}
