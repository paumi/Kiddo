using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Escena : MonoBehaviour
{

    /*public void cambiarescena(string nombre_escena){

        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(nombre_escena, LoadSceneMode.Single);
    }*/

    public GameObject loadingScreen;
    public Slider slider;

    public void CambiarEscena(string nombre_escena)
    {

        //"Reiniciar" el juego
        ShowMenuPause.juegoEnPausa = false;
        Time.timeScale = 1f;

        //Cargar escena
        StartCoroutine(LoadAsynchronously(nombre_escena));      
    }

    IEnumerator LoadAsynchronously(string nombre_escena)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(nombre_escena);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
