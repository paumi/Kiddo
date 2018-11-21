using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour {

    public GameObject change;
    public GameObject changeScreen;
    public bool touching = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(touching && Input.GetKeyDown("enter"))
        {
            changeScreen.GetComponent<changeLevelScreen>().available = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(change);
        Debug.Log("Ha entrado");
        touching = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject destroyMessage = GameObject.FindGameObjectWithTag("cambio");
        Destroy(destroyMessage);
        touching = false;
        changeScreen.GetComponent<changeLevelScreen>().available = false;
        Debug.Log("Ha salido");
    }

}
