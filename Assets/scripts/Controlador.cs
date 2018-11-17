﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour {

	public void CambiarEscena(string nombre)
    {
        print("Cambia a escena" + nombre);
        SceneManager.LoadScene(nombre);
    }
    public void Salir()
    {
        print("Saliendo del juego");
        Application.Quit();
    }
}
