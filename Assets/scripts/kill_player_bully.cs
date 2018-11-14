using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_player_bully : MonoBehaviour{

    GameObject Kiddo;
    // Use this for initialization
    void Start()
    {
        Kiddo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {



    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
