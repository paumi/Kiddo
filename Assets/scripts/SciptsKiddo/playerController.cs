using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public float speed;
    public float sprint;
    public float jumpForce;
    public float stamina;
    public bool frozen;

    public bool invencible;
    private float invencibleTime;
    private float invencibleTimeMax;

    private float moveInputH;
    private float moveInputV;

    public BoxCollider2D upCollider;
    public SpriteRenderer sprite;

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

        frozen = false;

        extraJump = extraJumpValue;

        rb = GetComponent<Rigidbody2D>();
                                              /*********Amparo***********/
        nrbAmparo = GetComponentInParent<Rigidbody2D>();
                                               /**********AmparoFin******/
        facingRight = true;
        sprintCharged = true;
        isDying = false;
        jumpRequest = false;
        invencible = false;

        invencibleTime = 1f;
        invencibleTimeMax = 1f;

    }

    //Es recomendable para hacer cambios en el rigidbody

    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInputH = Input.GetAxis("Horizontal");

        moveInputV = Input.GetAxis("Vertical");

        if (invencible)
        {
            sprite.enabled = !sprite.enabled;
        }
        else
        {
            sprite.enabled = true;
        }

        //Debug.Log(isDead);
        if (!isDead && !frozen)
        {
            if (!(moveInputV < 0))
            {
                //Movimiento en el eje horizontal
                upCollider.enabled = true;
                if (moveInputH != 0)
                {
                    if ((Input.GetKey(KeyCode.LeftShift) || Input.GetButton("sprint")) && sprintCharged)
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
                    else
                    {
                        rb.velocity = new Vector2(moveInputH * speed, rb.velocity.y);
                        animator.SetBool("running", false);
                        chargeStamina();

                    }
                }
                else
                {
                    animator.SetBool("running", false);
                    chargeStamina();
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    
                }





                //Darle la vuelta al sprite cuando mira hacia la izquierda

                if (moveInputH > 0 && facingRight == false)
                {
                    Flip();
                }
                else if (moveInputH < 0 && facingRight == true) { Flip(); }
            }
            else
            {
                rb.velocity = new Vector2( 0, rb.velocity.y);
                upCollider.enabled = false;
                animator.SetBool("running", false);
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
        else { rb.velocity = new Vector2(0, rb.velocity.y); }

        //cambiamos la variable Speed (ver Animator) para cambiar la animación

        animator.SetFloat("Speed", Mathf.Abs(moveInputH * speed));

        if (invencible)
        {
            if (invencibleTime < 0)
            {
                invencibleTime = invencibleTimeMax;
                invencible = false;
            }
            else { invencibleTime -= (Time.deltaTime/2); }


        }

    }

    

    private void Update()
    {
        //se maneja el salto 
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && !ShowMenuPause.juegoEnPausa)
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

        transform.Rotate(0f, 180f, 0f);
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

        if (col.gameObject.tag == "Harmfull")
        {
            if (!invencible)
            {
                invencible = true;
                gameObject.GetComponent<atributes>().life--;
            }
        }            
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "escudo")
        {
            if (gameObject.GetComponent<atributes>().life < 2)
            {
                Debug.Log("vidaExtra");
                gameObject.GetComponent<atributes>().life++;
            }

        }

        if (col.gameObject.tag == "cohete")
        {

            Debug.Log("extraJump");
            extraJumpValue = 1;
 

        }

        if (col.gameObject.tag == "pelota")
        {
            Debug.Log("pelota");
            SceneManager.LoadScene("Menu");


        }
    }

}


