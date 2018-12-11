using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raios : Base_Enemys {

    public GameObject Descarga;
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
            Player = other.gameObject;
            Instantiate(Descarga, other.transform.position, other.transform.rotation);
            FPS_jugador.instance.vidaPlayer -= 20;

        }
    }

    protected override void Estadoestatico()
    {
        throw new System.NotImplementedException();
    }

    protected override void Estadopatrullaje()
    {
        throw new System.NotImplementedException();
    }

    protected override void Estadopersecucion()
    {
        throw new System.NotImplementedException();
    }

    protected override void EstadoDisparar()
    {
        throw new System.NotImplementedException();
    }
}
