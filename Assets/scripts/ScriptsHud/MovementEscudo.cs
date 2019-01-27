using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEscudo : MonoBehaviour
{

    GameObject camera;

    private float posX;
    private float posY;

    private GameObject kiddo;
    private float energy;

    [SerializeField] private Sprite escudo;

    // Use this for initialization
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        kiddo = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate()
    {
        posX = camera.transform.position.x - 3;
        posY = camera.transform.position.y + 8;

        transform.position = new Vector2(posX, posY);
    }

    // Update is called once per frame
    void Update()
    {
        if (kiddo.GetComponent<atributes>().life > 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = escudo;
        }
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }
}
