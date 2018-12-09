using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Enemys : MonoBehaviour {
    public GameObject Bala;
    public GameObject Player;
    public Transform[] waypoints;
    public float distanciaTarget;
    public UnityEngine.AI.NavMeshAgent Agente;

    // Use this for initialization
     void Start() {
        Agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {

    }
    protected abstract void Estadoestatico();
    protected abstract void Estadopatrullaje();
   protected abstract void Estadopersecucion();
    protected abstract void EstadoDisparar();

}
