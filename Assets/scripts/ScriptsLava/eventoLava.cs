using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventoLava : MonoBehaviour {

    float tiempo;
    public GameObject wallLeft, wallRight, colliderLava, ground;
    public GameObject msg , player;
    bool caged = false;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        
        if (caged)
        {
            GameObject msgDestroy = GameObject.FindGameObjectWithTag("text");
            ground.GetComponent<moveGround>().start = true;

            if (Input.GetKeyDown("w"))
            {
                Destroy(msgDestroy);
                //WallController(false);
                player.GetComponent<playerController>().frozen = false;
                caged = false;
                colliderLava.SetActive(false);

            }
            
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<playerController>().frozen = true;
        //WallController(true);
        caged = true;
        Instantiate(msg);
    }

    private void WallController(bool active)
    {
        wallLeft.SetActive(active);
        wallRight.SetActive(active);
    }
}
