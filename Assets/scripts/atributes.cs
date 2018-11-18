using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributes : MonoBehaviour {

    public int life = 1;
    public GameObject spawn;

	// Use this for initialization
	void Start () {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
	}
	
	// Update is called once per frame
	void Update () {

        if (!CheckLife())
            ReSpawn();
	}

    bool CheckLife()
    {
        if (life == 0)
        {
            life = 1;
            return false;
        }

        else
            return true;
    }

    void ReSpawn()
    {
        transform.position = spawn.transform.position;
    }
}
