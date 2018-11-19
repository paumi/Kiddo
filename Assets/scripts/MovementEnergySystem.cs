using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnergySystem : MonoBehaviour {

    GameObject camera;

    private float posX;
    private float posY;

    private GameObject kiddo;
    private float energy;

    Animator animator;

	// Use this for initialization
	void Start () {

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        kiddo = GameObject.FindGameObjectWithTag("Player");
        energy = kiddo.GetComponent<playerController>().stamina;

        animator = gameObject.GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        posX = camera.transform.position.x - 10;
        posY = camera.transform.position.y + 8;

        transform.position = new Vector2(posX,posY); 
    }
    // Update is called once per frame
    void Update () {

        energy = kiddo.GetComponent<playerController>().stamina;
        animator.SetFloat("Energy", energy);

	}
}
