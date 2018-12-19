using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAdvertencia : MonoBehaviour {

    public AudioClip Advertencia;
    AudioSource fuenteAudio;

    // Use this for initialization
    void Start () {
        fuenteAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("w"))
        {
            fuenteAudio.clip = Advertencia;
            fuenteAudio.Play();
        }
    }
}