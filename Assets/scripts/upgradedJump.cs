using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradedJump : MonoBehaviour {

    //variables que se utiizan para el salto mantenido

    private Rigidbody2D rb;
    public float fullJumpMultiplier; //multiplicador maximo para la gravedad
    public float lowJumpMultiplier;  //multiplicador mínimo para la gravedad

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        fullJumpMultiplier = 10f;
        lowJumpMultiplier = 15f;
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y) * (fullJumpMultiplier - 1) * Time.deltaTime;
        }
        else
        {
            if (rb.velocity.y > 0 && !(Input.GetButton("jumpKeyboard") || Input.GetButton("Jump")))
            {
                rb.velocity += Vector2.up * (Physics2D.gravity.y) * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
