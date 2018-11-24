using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapareceNube : MonoBehaviour {

    public float duracion = 3f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator DestruirNube() {

        yield return new WaitForSeconds(duracion);

        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duracion);

        GetComponent<Collider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            StartCoroutine(DestruirNube());
        }

    }
}
