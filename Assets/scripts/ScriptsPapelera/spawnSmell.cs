using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSmell : MonoBehaviour {

    // Use this for initialization
    public GameObject smell;
    float time = 0;

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= 3f)
        {
            Instantiate(smell, transform);
            time = 0;
        }
        
	}
}
