using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAlas : MonoBehaviour
{

    GameObject camera;

    private float posX;
    private float posY;

    private GameObject kiddo;
    private float energy;

    [SerializeField] private Sprite alas;

    // Use this for initialization
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        kiddo = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate()
    {
        posX = camera.transform.position.x;
        posY = camera.transform.position.y + 8;

        transform.position = new Vector2(posX, posY);
    }

    // Update is called once per frame
    void Update()
    {
        if (kiddo.GetComponent<playerController>().extraJumpValue > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = alas;
        }
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }
}
