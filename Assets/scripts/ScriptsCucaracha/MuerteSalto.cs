using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteSalto : MonoBehaviour {

    public GameObject cucaracha;
    public GameObject Kiddo;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            cucaracha.SetActive(false);
            Kiddo.GetComponent<playerController>().rb.velocity = Vector2.up * Kiddo.GetComponent<playerController>().jumpForce;
            Debug.Log("Salto");
        }
    }
}
