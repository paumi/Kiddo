using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public GameObject itself;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(itself);
    }
}
