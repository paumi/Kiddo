using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventoLava : MonoBehaviour {

    public GameObject wallLeft, wallRight;
    public GameObject msg;
    bool caged = false;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (caged)
        {
            Instantiate(msg);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WallController(true);
        caged = true;
    }

    private void WallController(bool active)
    {
        wallLeft.SetActive(active);
        wallRight.SetActive(active);
    }
}
