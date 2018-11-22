using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenuPause : MonoBehaviour {

    public static bool juegoEnPausa;

    public GameObject menuPausa;   

	// Use this for initialization
	void Start () {

        juegoEnPausa = false;
	}
	
	// Update is called once per frame
	private void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (juegoEnPausa) DesactivarMenu();
            else ActivarMenu();
        }

	}

    private void ActivarMenu()
    {
        menuPausa.SetActive(true);
        juegoEnPausa = true;
        Time.timeScale = 0f;
    }

    public void DesactivarMenu()
    {
        menuPausa.SetActive(false);
        juegoEnPausa = false;
        Time.timeScale = 1f;
    }
}
