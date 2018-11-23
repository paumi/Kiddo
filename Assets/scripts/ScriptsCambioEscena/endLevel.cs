using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endLevel : MonoBehaviour {

    public GameObject change;
    public GameObject changeScreen;
    public bool touching = false;

    public GameObject loadingScreen;
    public Slider slider;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(touching && Input.GetKeyDown("w"))
        {

            //Cargar escena
            StartCoroutine(LoadAsynchronously("Patio"));
            //changeScreen.GetComponent<changeLevelScreen>().available = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(change);
        Debug.Log("Ha entrado");
        touching = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject destroyMessage = GameObject.FindGameObjectWithTag("cambio");
        Destroy(destroyMessage);
        touching = false;
        changeScreen.GetComponent<changeLevelScreen>().available = false;
        Debug.Log("Ha salido");
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
