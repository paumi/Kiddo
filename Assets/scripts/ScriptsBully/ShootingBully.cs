using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBully : MonoBehaviour {

    public float tiempo;

    public Transform firePoint;
    public GameObject ball;
    public AudioClip lanzar;
    AudioSource fuenteAudio;

	// Use this for initialization
	void Start () {
        fuenteAudio = GetComponent<AudioSource>();
        tiempo = 5f;
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
