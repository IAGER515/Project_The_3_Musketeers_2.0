using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_CuerpoCuerpo : Base_Enemys
{
    public enum EstadoMaquina { estatico, patrullaje, persecucion };
    public EstadoMaquina estadoActual;
    public Camera gameCamara;
    NavMeshAgent agente; // NPC
    int numWaypoint = 0;
    float auxVelocidad;
    public float distancia;
    public float tiempoEspera;
    

    // Use this for initialization
      void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        auxVelocidad = agente.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Estadoestatico();
        Estadopatrullaje();
        Estadopersecucion();
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

    protected override void Estadopersecucion()
    {
        if (Player != null && Vector3.Distance(transform.position, Player.transform.position) <= distanciaTarget)
        {
            Agente.isStopped = false;
            Agente.destination = Player.transform.position;
            if (Agente.remainingDistance <= Agente.stoppingDistance && !Agente.pathPending)
            {
                Agente.isStopped = true;

            }
        }
    }
}
