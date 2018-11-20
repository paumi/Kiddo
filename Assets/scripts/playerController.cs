using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    public float sprint;
    public float jumpForce;
    public float stamina;
    private float moveInputH;
    private float moveInputV;

    private bool isDying;

    private bool facingRight;
    public bool sprintCharged;
    private bool jumpRequest;

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

    //*******************ampliacion Amparo*******//

    private Rigidbody2D nrbAmparo;

    //******************finAmparo*************//

	// Use this for initialization

	void Start () {

        extraJump = extraJumpValue;

        rb = GetComponent<Rigidbody2D>();
                                              /*********Amparo***********/
        nrbAmparo = GetComponentInParent<Rigidbody2D>();
                                               /**********AmparoFin******/
        facingRight = true;
        sprintCharged = true;
        isDying = false;
        jumpRequest = false;

    }

    //Es recomendable para hacer cambios en el rigidbody

    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInputH = Input.GetAxisRaw("Horizontal");
        moveInputV = Input.GetAxis("Vertical");

        //Debug.Log(isDead);
        if (!isDead)
        {
            if (!(moveInputV < 0))
            {
                //Movimiento en el eje horizontal
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetButton("sprint")) && sprintCharged)
                {
                    if (moveInputH != 0)
                    {
                        rb.velocity = new Vector2(moveInputH * sprint, rb.velocity.y);
                        stamina -= Time.deltaTime;
                        //Debug.Log(stamina);
                        animator.SetBool("running", true);
                        if (stamina <= 0)
                        {
                            sprintCharged = false;
                        }
                    }
                    else { animator.SetBool("running", false); }
                }

                else
                {
                    animator.SetBool("running", false);
                    rb.velocity = new Vector2(moveInputH * speed, rb.velocity.y);
                    chargeStamina();
                }



                //Darle la vuelta al sprite cuando mira hacia la izquierda

                if (moveInputH > 0 && facingRight == false)
                {
                    Flip();
                }
                else if (moveInputH < 0 && facingRight == true) { Flip(); }
            }

            if (jumpRequest)
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

                jumpRequest = false;
            }
        }

        //cambiamos la variable Speed (ver Animator) para cambiar la animación

        animator.SetFloat("Speed", Mathf.Abs(moveInputH * speed));

    }

    

    private void Update()
    {
        //se maneja el salto 
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")))
        {
            jumpRequest = true;
        }


        isDead = gameObject.GetComponent<atributes>().dying;

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

    void chargeStamina()
    {
        if (stamina < 3)
        {
            stamina += Time.deltaTime;
        }
        else
        {
            if (!sprintCharged)
            {
                sprintCharged = true;
            }
        }
    }
    //para detectar colisiones con plataformas moviles y que pueda seguir su movimiento cuando esta sobre ellas

    void OnCollisionStay2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "PlatformMovil")
        {
            transform.parent = col.transform;
        }
    }


     void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlatformMovil")
        {
            transform.parent = null;
        }
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlatformMovil")
        {
            nrbAmparo.velocity = new Vector3(0f, 0f, 0f);
            transform.parent = col.transform;
        }
    }

    //Fin plataformas moviles

}


