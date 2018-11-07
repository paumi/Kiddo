using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInputH;
    private float moveInputV;

    private bool facingRight = true;

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

		
	}

    //Se llama cada frame y se utiliza para manejar las colisiones

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInputH = Input.GetAxisRaw("Horizontal");
        moveInputV = Input.GetAxis("Vertical");
        

        //comprobamos si toca los limites de muerte

        isDead = Physics2D.OverlapCircle(groundCheck.position, checkRadius, boundsD);

        if (isDead)
        {
            Destroy(gameObject);
        }

        //Si no está agachado kiddo no puede moverse

        if(!(moveInputV < 0))
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
        //cambiamos la variable Speed (ver Animator) cambiar la animación

        animator.SetFloat("Speed", Mathf.Abs(moveInputH * speed));
    }

    // Se llama cada frame

    private void Update()
    {

        //Se comprueba que está en el suelo

        if (isGrounded)
        {
            //cambiamos la variable Speed (ver Animator) cambiar la animación

            animator.SetBool("Jumping", false);

            //Restablecemos el numero de saltos que se pueden dar antes de tocar el suelo

            extraJump = extraJumpValue;
        }
        else
        {
            //Si no se está en el suelo la animación de saltar se ejecuta

            animator.SetBool("Jumping", true);
        }

        //se maneja el salto 

        if(extraJump > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }

        //Se maneja si se agacha o no

        if (moveInputV < 0)
        {
            animator.SetBool("Down", true);
        }
        else { animator.SetBool("Down", false); }
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
