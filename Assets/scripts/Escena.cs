﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena : MonoBehaviour {

    public void cambiarescena(string nombre_escena){

        SceneManager.LoadScene(1);
    }
}
