﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltoDoble : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
