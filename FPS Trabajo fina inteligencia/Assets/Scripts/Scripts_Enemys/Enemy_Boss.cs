using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy_Boss : Base_Enemys {

    NavMeshAgent agente;
    float auxVelocidad;
    public float BossLife = 1000;
    public GameObject escudo;



    protected override void Estadoestatico()
    {
        if(BossLife >= 500)
        {
            escudo.SetActive(false);
        }
       
    }
    public void Rage()
    {
        if (BossLife <500)
        {
           
            escudo.SetActive(true);
        }

    }

    protected override void Estadopatrullaje()
    {
        throw new System.NotImplementedException();
    }

    protected override void Estadopersecucion()
    {
        throw new System.NotImplementedException();
    }



    // Use this for initialization
    void Start () {
        agente = GetComponent<NavMeshAgent>();
        auxVelocidad = agente.speed;
    }
	
	// Update is called once per frame
	void Update () {
        Estadoestatico();
        Rage();
	}
}
