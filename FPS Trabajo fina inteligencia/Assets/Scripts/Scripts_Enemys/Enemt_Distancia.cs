using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemt_Distancia : Base_Enemys
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

    // Use this for initialization
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        auxVelocidad = agente.speed;
        InvokeRepeating("EstadoDetectar", iniciobala, esperabala);

    }

    // Update is called once per frame
    void Update()
    {
        Estadoestatico();
        Estadopatrullaje();
        EstadoDetectar();
    }

    protected override void Estadoestatico()
    {
        if (estadoActual == EstadoMaquina.estatico)
        {
            tiempoEspera++;
            if (tiempoEspera == 120)
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
            }
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
                Instantiate(Bala, balaposicion.position, balaposicion.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("colision");
            Player = other.gameObject;
            estadoActual = EstadoMaquina.detectar;
            agente.isStopped = true;
        }
        if (other.tag == "Bullet")
        {
            Debug.Log("pego");
            VidaEnemyDistancia = VidaEnemyDistancia - 10;
        }
        if (other.tag == "BulletEscopeta")
        {
            Debug.Log("pegoEscopeta");
            VidaEnemyDistancia = VidaEnemyDistancia - 10;
        }
        if (VidaEnemyDistancia == 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected override void Estadopersecucion()
    {
        throw new System.NotImplementedException();
    }
}
