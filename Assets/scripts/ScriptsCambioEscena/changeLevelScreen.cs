using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevelScreen : MonoBehaviour {

    public bool paused = false;
    public bool available = false;
    public GameObject changeLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (available)
        {
            ShowScreen();
        }
    }

    private void ShowScreen()
    {
        changeLevel.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void HideScreen()
    {
        paused = false;
        Time.timeScale = 1f;
        changeLevel.SetActive(false);
    }


    public void onClick()
    {
        SceneManager.LoadScene("Patio");
    }

    public void OnClickNo()
    {
        HideScreen();
    }
}
