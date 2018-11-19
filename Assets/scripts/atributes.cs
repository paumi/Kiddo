using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributes : MonoBehaviour {

    public int life = 1;
    public GameObject spawn;
    public bool dying;
    private float animationTime;
    private float maxAnimaionTime;
    Animator animator;

	// Use this for initialization
	void Start () {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        dying = false;

        animationTime = 1.5f;
        maxAnimaionTime = 1.5f;

        animator = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {


        if (dying)
        {
            if (animationTime < 0)
            {
                animationTime = maxAnimaionTime;
                dying = false;
                ReSpawn();
            }
            else
            {
                animationTime -= Time.deltaTime;
            }
        }

        CheckLife();              

        if (!dying)
        {
            animator.SetBool("Dead", false);
        }
	}

    bool CheckLife()
    {
        if (life == 0)
        {
            dying = true;
            animator.SetBool("Dead", true);
            life = 1;
            return false;
        }

        else
            return true;
    }

    void ReSpawn()
    {
        transform.position = spawn.transform.position;
    }
}
