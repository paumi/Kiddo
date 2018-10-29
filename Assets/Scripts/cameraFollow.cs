using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    GameObject Kiddo;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        Kiddo = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position + Kiddo.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Kiddo.transform.position + offset;
	}
}
