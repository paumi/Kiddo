using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySmell : MonoBehaviour {

    float time = 0;
    Collider2D collision;
    GameObject lePlayer;
    public bool col = false;

	// Use this for initialization
	void Start () {
        lePlayer = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= 1.5f)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lePlayer.GetComponent<atributes>().life = 0;
    }
}
