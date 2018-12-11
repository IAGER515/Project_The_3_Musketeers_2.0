using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] Escenas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CargarEscenas();
	}

    public void CargarEscenas()
    {
        if (Enemt_Distancia.instance.VidaEnemyDistancia <= 0 && Enemy_CuerpoCuerpo.instance.VidaEnemyCuerpo <= 0)
        {

            SceneManager.LoadScene("1");

        }
    }
}
