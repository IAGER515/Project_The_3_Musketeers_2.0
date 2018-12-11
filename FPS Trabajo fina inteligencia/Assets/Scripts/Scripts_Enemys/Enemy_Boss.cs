using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Boss : Base_Enemys
{

    public float VidaBoss = 1000;
    public GameObject Escudo;
    NavMeshAgent Agent;
    public GameObject muertoBoss;
    public Transform balaposicion;
    public GameObject Descarga;

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
            VidaBoss += 0.01f;
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
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        InvokeRepeating("EstadoDisparar", 0.2f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        Estadoestatico();
        Rage();

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
        if (VidaBoss <= 0)
        {
            muertoBoss.SetActive(true);
            Destroy(gameObject, 5f);
            Destroy(this.gameObject);
        }
    }

    protected override void EstadoDisparar()
    {
        transform.LookAt(Player.transform.position);
        Instantiate(Bala, balaposicion.position, balaposicion.rotation);


    }
}
