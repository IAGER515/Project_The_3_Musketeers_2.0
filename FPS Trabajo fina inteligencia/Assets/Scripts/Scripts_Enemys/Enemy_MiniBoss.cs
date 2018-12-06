using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MiniBoss : MonoBehaviour {
    public float VidaMiniBoss;
    public GameObject MuertoMiniBoss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("colision");

        }
        if (other.tag == "Bullet")
        {
            Debug.Log("pego");
            VidaMiniBoss -= 10;
            GameObject hpObj = GameObject.Find("VidaMiniBoss");
            Vector3 scale = hpObj.transform.localScale;
            scale.x = (float)VidaMiniBoss / 100f;
            hpObj.transform.localScale = scale;
        }
        if (other.tag == "BulletEscopeta")
        {
            Debug.Log("pegoEscopeta");
            VidaMiniBoss -= 15;
            GameObject hpObj = GameObject.Find("VidaMiniBoss");
            Vector3 scale = hpObj.transform.localScale;
            scale.x = (float)VidaMiniBoss / 100f;
            hpObj.transform.localScale = scale;
        }
        if (VidaMiniBoss == 0)
        {
            MuertoMiniBoss.SetActive(true);
            Destroy(gameObject, 5f);
            Destroy(this.gameObject);
        }
    }
}
