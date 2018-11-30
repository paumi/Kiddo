using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour {

    GameObject Kiddo;
	// Use this for initialization
	void Start () {
        Kiddo = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("golpeado");
        Kiddo.GetComponent<atributes>().life--;
    }
}
