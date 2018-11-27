using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGround : MonoBehaviour {

    public Transform ground;
    public float speed;
    public bool start;
    float step;
    Vector3 target;
	// Use this for initialization
	void Start () {
       target = new Vector3(transform.position.x, transform.position.y - 20, step);
	}
	
	// Update is called once per frame
	void Update () {
        if(start)
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target,step);
	}
}
