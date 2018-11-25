using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBully : MonoBehaviour {

    public float tiempo;

    public Transform firePoint;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        tiempo = 3f;
        InvokeRepeating("shooting", tiempo, tiempo);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void shooting()
    {
        Instantiate(ball, firePoint.position, firePoint.rotation);
    }
}
