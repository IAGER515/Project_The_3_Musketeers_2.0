using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Boss : Base_Enemys {

    public float VidaBoss = 1000;
    public GameObject Escudo;
    NavMeshAgent Agent;
    public GameObject muertoBoss;

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
     void Start() {
        Agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {

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
            VidaBoss -= 10;
            GameObject hpObj = GameObject.Find("VidaBoss");
            Vector3 scale = hpObj.transform.localScale;
            scale.x = (float)VidaBoss / 100f;
            hpObj.transform.localScale = scale;
        }
        if (other.tag == "BulletEscopeta")
        {
            Debug.Log("pegoEscopeta");
            VidaBoss -= 15;
            GameObject hpObj = GameObject.Find("VidaBoss");
            Vector3 scale = hpObj.transform.localScale;
            scale.x = (float)VidaBoss / 100f;
            hpObj.transform.localScale = scale;
        }
        if (VidaBoss == 0)
        {
            muertoBoss.SetActive(true);
            Destroy(gameObject, 5f);
            Destroy(this.gameObject);
        }
    }

    protected override void EstadoDisparar()
    {
        throw new System.NotImplementedException();
    }
}
