using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_CuerpoCuerpo : Base_Enemys
{
    public enum EstadoMaquina { estatico, patrullaje, persecucion };
    public EstadoMaquina estadoActual;
    public float VidaEnemyCuerpo = 100f;
    public Camera gameCamara;
    NavMeshAgent agente; // NPC
    int numWaypoint = 0;
    public float auxVelocidad;
    public float distancia;
    public float tiempoEspera;

    // Use this for initialization
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        auxVelocidad = agente.speed;
    }

    void Update()
    {
        Estadoestatico();
        Estadopatrullaje();
        Estadopersecucion();
    }

    // Update is called once per frame
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

    protected override void Estadopersecucion()
    {
        if (Player != null && Vector3.Distance(transform.position, Player.transform.position) <= distanciaTarget)
        {
            agente.isStopped = false;
            agente.destination = Player.transform.position;
            if (agente.remainingDistance <= agente.stoppingDistance && !agente.pathPending)
            {
                agente.isStopped = true;

            }
        }
    }


void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            Debug.Log("pego");
            VidaEnemyCuerpo = VidaEnemyCuerpo - 10;
        }
        if (other.tag == "BulletEscopeta")
        {
            Debug.Log("pegoEscopeta");
            VidaEnemyCuerpo = VidaEnemyCuerpo - 15;
        }
        if (VidaEnemyCuerpo == 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected override void EstadoDisparar()
    {
        throw new System.NotImplementedException();
    }
}
