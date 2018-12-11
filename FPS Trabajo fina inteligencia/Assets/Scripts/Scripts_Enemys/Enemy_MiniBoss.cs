using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy_MiniBoss : Base_Enemys
{
    public enum EstadoMaquina { estatico, patrullaje, detectar, ataque };
    public EstadoMaquina estadoActual;
    public Camera gameCamara;
    NavMeshAgent agente; // NPC
    int numWaypoint = 0;
    float auxVelocidad;
    public float distancia;
    public float tiempoEspera;
    public float iniciobala;
    public float esperabala;
    public float VidaEnemyDistancia = 100f;
    public Transform balaposicion;



    protected override void EstadoDisparar()
    {
        if (estadoActual == EstadoMaquina.ataque)
        {
           
        }
    }
    protected void EstadoDetectar()
    {
        if (estadoActual == EstadoMaquina.detectar)
        {

            if (Vector3.Distance(transform.position, agente.transform.position) < distancia)
            {
                agente.stoppingDistance = 3f;
                transform.LookAt(Player.transform.position);
                EstadoDisparar();
                estadoActual = EstadoMaquina.ataque;

            }
        }
    }

    protected override void Estadoestatico()
    {
        if (estadoActual == EstadoMaquina.estatico)
        {
            tiempoEspera++;
            if (tiempoEspera == 100)
            {
                estadoActual = EstadoMaquina.patrullaje;
                return;
            }
        }
    }

    protected override void Estadopatrullaje()
    {
        if (estadoActual == EstadoMaquina.patrullaje)
        {
            agente.speed = auxVelocidad;
            if (agente.remainingDistance <= agente.stoppingDistance && agente.pathPending == false)
            {
                numWaypoint = (numWaypoint + 1) % waypoints.Length;
                agente.destination = waypoints[numWaypoint].position;
                Debug.Log("disparo");
                transform.LookAt(Player.transform.position);
                Instantiate(Bala, balaposicion.position, balaposicion.rotation);
            }
        }
    }

    protected override void Estadopersecucion()
    {
        throw new System.NotImplementedException();
    }

    public float VidaMiniBoss;
    public GameObject MuertoMiniBoss;
    // Use this for initialization


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("colision");
            FPS_jugador.instance.vidaPlayer -= 10;
            Debug.Log("golpeo");

        }
        if (other.tag == "Bullet")
        {
            Debug.Log("pego");
            VidaMiniBoss -= 10;
            GameObject hpObj = GameObject.Find("VidaMiniBoss");
            Vector3 scale = hpObj.transform.localScale;
            scale.x = (float)VidaMiniBoss / 100f;
            hpObj.transform.localScale = scale;
            //esquivar
            int esquivar = Random.Range(0, 5);
            numWaypoint = (numWaypoint + 1) % waypoints.Length;
            agente.destination = waypoints[esquivar].position;

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
        if (VidaMiniBoss <= 0)
        {
            MuertoMiniBoss.SetActive(true);
            Destroy(gameObject, 5f);
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        auxVelocidad = agente.speed;
        InvokeRepeating("EstadoDisparar", iniciobala, esperabala);
    }

    // Update is called once per frame
    void Update()
    {
        Estadoestatico();
        Estadopatrullaje();
        EstadoDetectar();
    }
}
