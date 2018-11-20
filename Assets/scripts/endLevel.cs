using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour {

    public GameObject change;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //change = GameObject.FindGameObjectWithTag("cambio");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(change);
        Debug.Log("Ha entrado");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject destroyMessage = GameObject.FindGameObjectWithTag("cambio");
        Destroy(destroyMessage);
        Debug.Log("Ha salido");
    }
}
