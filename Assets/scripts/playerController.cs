using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInputH;
    private float moveInputV;

    private bool facingRight;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public LayerMask boundsD;
    private bool isDead;

    public int extraJumpValue;
    private int extraJump;

    private Rigidbody2D rb;

    public Animator animator;

	// Use this for initialization

	void Start () {

        extraJump = extraJumpValue;

        rb = GetComponent<Rigidbody2D>();

        facingRight = true;

    }

    //Es recomendable para hacer cambios en el rigidbody

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInputH = Input.GetAxisRaw("Horizontal");
        moveInputV = Input.GetAxis("Vertical");


        //comprobamos si toca los limites de muerte

        //isDead = Physics2D.OverlapCircle(groundCheck.position, checkRadius, boundsD);

        //if (isDead)
        //{
        //Destroy(gameObject);
        //}

        //Si no está agachado kiddo no puede moverse


        if (!(moveInputV < 0))
        {
            //Movimiento en el eje horizontal

            rb.velocity = new Vector2(moveInputH * speed, rb.velocity.y);

            //Darle la vuelta al sprite cuando mira hacia la izquierda

            if (moveInputH > 0 && facingRight == false)
            {
                Flip();
            }
            else if (moveInputH < 0 && facingRight == true) { Flip(); }
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //cambiamos la variable Speed (ver Animator) para cambiar la animación

        animator.SetFloat("Speed", Mathf.Abs(moveInputH * speed));

        //Se comprueba que está en el suelo

    }

    

    private void Update()
    {
        //se maneja el salto 
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            else
            {
                if (extraJump > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJump--;
                }
            }
        }
        

        //Se maneja si se agacha o no

        if (moveInputV < 0)
        {
            animator.SetBool("Down", true);
        }
        else { animator.SetBool("Down", false); }

        if (isGrounded)
        {

            //Restablecemos el numero de saltos que se pueden dar antes de tocar el suelo
            animator.SetBool("Jumping", false);
            extraJump = extraJumpValue;
        }
        else
        {
            //Si no se está en el suelo la animación de saltar se ejecuta
            animator.SetBool("Jumping", true);

        }
    }



    //Función para cmbiar la dirección de los sprites

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    

}


