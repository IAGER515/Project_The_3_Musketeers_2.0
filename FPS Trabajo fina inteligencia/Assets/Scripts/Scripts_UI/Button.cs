using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        SceneManager.LoadScene("Enemys");
    }
    public void OnclickBoss()
    {
        SceneManager.LoadScene("Boss");
    }
    public void OnclickMiniBoss()
    {
        SceneManager.LoadScene("MiniBoss");
    }
}
