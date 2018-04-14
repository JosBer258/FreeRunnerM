using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MostrarEscenea(string FV_SceName)
    {
        SceneManager.LoadScene(FV_SceName);
    }

    public void CerrarAplicacion()
    {
        Application.Quit();
        //Debug.Log("cierre");
    }
}
