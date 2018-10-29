using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed;
    bool speedChange = false;
    public float jumpForce;
    public bool grounded;
    bool isFacingRight = true;
    bool isAxisInUse;
    public Transform groundCheck;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


    }

    private void FixedUpdate()
    {
        float moveVertical = 0;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveHorizontal *= Time.deltaTime;

        Debug.Log(moveHorizontal);

        ControlFlip(moveHorizontal);
       
        if (CheckGround() && Input.GetKeyDown("space") /*checkAxisUse()*/)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        Vector2 move = new Vector2(moveHorizontal, moveVertical);

        Debug.Log("Jump: " + Input.GetAxis("Jump"));

        transform.Translate(move);
    }

    bool checkAxisUse()
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            if (isAxisInUse == false)
            {
                // Call your event function here.
                isAxisInUse = true;
                return isAxisInUse;
            }
        }
        if (Input.GetAxisRaw("Jump") == 0)
        {
            isAxisInUse = false;
            return isAxisInUse;
        }
        isAxisInUse = false;
        return false;
    }

    void ControlFlip(float moveHorizontal)
    {
        if (moveHorizontal < -0.01f)
        {
            if (isFacingRight)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                isFacingRight = false;
            }
        }

        else if(moveHorizontal > 0.01f)
        {
            if (!isFacingRight)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isFacingRight = true;
            }
        }
    }

    bool CheckGround()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform")))
            {
            if (speedChange)
            {
                speed *= 1.5f;
                speedChange = false;
            }
            return true;
        }
        else
        {
            if (!speedChange)
            {
                speed /= 1.5f;
                speedChange = true;
            }
            return false;
        }
    }
}

