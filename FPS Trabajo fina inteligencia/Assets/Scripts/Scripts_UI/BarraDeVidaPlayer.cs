using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaPlayer : MonoBehaviour {
    public float Vida = 100f;
    float DanoVida;
    public Image vidaImage;

	// Use this for initialization
	void Start () {
        Vida = DanoVida;
        vidaImage.fillAmount = DanoVida / Vida;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala"))
        {
            //DañoVida -= other.GetComponent<bala>().;
            vidaImage.fillAmount = Vida / DanoVida;
            if (DanoVida <= 0)
            {
                //llamar mensaje de has muerto
            }
        }
    }
}
