using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioSpawn : MonoBehaviour {

    public GameObject spawn, player;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D collision){
        player.GetComponent<atributes>().spawn = spawn;

    }
}
