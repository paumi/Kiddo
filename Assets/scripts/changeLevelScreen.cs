using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        changeLevel.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }
}
