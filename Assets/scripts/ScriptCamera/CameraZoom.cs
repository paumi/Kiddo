using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    private float currentCameraSize; //La inicial
    private float zoomedCameraSize; //La cantidad de zoom que queremos
    private float duracionZoom; //La duracion
    private bool zoom; //Si ya ha hecho el zoom o no

	// Use this for initialization
	void Start () {

        currentCameraSize = UnityEngine.Camera.main.orthographicSize;
        zoomedCameraSize = 7f;
        duracionZoom = 3f;
        zoom = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !zoom)
        {
            UnityEngine.Camera.main.orthographicSize = zoomedCameraSize;

            StartCoroutine(HacerZoom());

        }           
       
    }

    IEnumerator HacerZoom()
    {
        zoom = true;
        yield return new WaitForSeconds(duracionZoom);
        UnityEngine.Camera.main.orthographicSize = currentCameraSize;
    }


}
