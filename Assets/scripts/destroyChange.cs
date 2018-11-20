using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyChange : MonoBehaviour {

    public bool destroy;

	// Use this for initialization
	void Start () {
        destroy = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy) Destroy(this);
	}

}
