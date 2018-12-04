using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Boss : Base_Enemys {

    public float VidaBoss = 1000;
    public GameObject Escudo;
    NavMeshAgent Agent;





    protected override void Estadoestatico()
    {
        if (VidaBoss >= 500)
        {
            Escudo.SetActive(false);
        }
    }
    public void Rage()
    {
        if (VidaBoss < 500)
        {
            Escudo.SetActive(true);
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
    private void Start () {
		
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
            
       
          
        }
        if (other.tag == "Bullet")
        {
            Debug.Log("pego");
            VidaBoss -=  10;
        }
        if (other.tag == "BulletEscopeta")
        {
            Debug.Log("pegoEscopeta");
            VidaBoss -= 10;
        }
        if (VidaBoss == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
