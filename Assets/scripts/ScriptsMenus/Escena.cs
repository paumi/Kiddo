using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena : MonoBehaviour {

    /*public void cambiarescena(string nombre_escena){

        SceneManager.LoadScene(1);
    }*/

    public void CambiarEscena(string nombre_escena){

        //"Reiniciar" el juego
        ShowMenuPause.juegoEnPausa = false;
        Time.timeScale = 1f;

        //Cargar escena
        SceneManager.LoadScene(nombre_escena, LoadSceneMode.Single);
    }
}
