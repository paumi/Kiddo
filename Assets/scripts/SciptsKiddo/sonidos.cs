using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidos : MonoBehaviour {

    public AudioClip salto;
    public AudioClip caminar;
    public AudioClip muerte;
    public AudioClip daño;
    public AudioClip doblesalto;
    public AudioClip correr;
    AudioSource fuenteAudio;

    // Use this for initialization
    void Start () {

        fuenteAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fuenteAudio.clip = salto;
            fuenteAudio.Play();

        }

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetButton("sprint")))
        {
            fuenteAudio.clip = caminar;
            fuenteAudio.Play();
        }
    }
}


// fuenteAudio.clip = muerte;
// fuenteAudio.Play();
// fuenteAudio.clip = daño;
// fuenteAudio.Play();
// fuenteAudio.clip = doblesalto;
// fuenteAudio.Play();
// fuenteAudio.Play();