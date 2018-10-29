using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpOnEnemy : MonoBehaviour {

    public Rigidbody2D rb2d;
    float jumpForce;
    Collider collision;
    // Use this for initialization
    void Start () {
        jumpForce = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().jumpForce;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb2d.AddForce(Vector2.up * jumpForce*1.5f, ForceMode2D.Impulse);
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
