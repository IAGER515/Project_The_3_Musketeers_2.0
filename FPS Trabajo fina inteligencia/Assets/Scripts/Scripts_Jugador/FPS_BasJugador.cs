using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FPS_BasJugador : MonoBehaviour {
    public enum EstadoJugador {Mecanicas,Regeneracion};
    public EstadoJugador EstadoActual;
    public Camera CamaraJugador; // para guardar la camara del jugador 
    public float velocidadHorizontal;//para la velocidad al voltear horizontal movimiento del raton
    public float velocidadVertical;//para la velocidad al voltear vertical movimiento del raton
    public float movimientoHorizaontal;//para guardar la velocidad del movimiento del raton horizontal
    public float movimientoVertical;//para guardar la velocidad del movimiento del raton vertical
    public float VelSalto;
    public bool saltar = true;//varieble para ver si puede saltar al tocar el suelo{
    public Rigidbody rbd;
    public float vidaPlayer = 100f; // vida del Player 
    public GameObject PistolaNormal;//gameobject De pistola Normal
    public GameObject Escopeta;//gameobject De Escopeta 
	// Use this for initialization
	void Start () {

        rbd.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    public abstract void mecanicas();
}
