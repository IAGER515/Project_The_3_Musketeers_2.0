using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola_Normal : MonoBehaviour {
    public GameObject BalaPistolaNormal;//disparo del jugador 
    public Transform PosDisPisNormal;//para la posicion donde se va spauniar la bala 
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Disparo Pistola Normal");
            Instantiate(BalaPistolaNormal, PosDisPisNormal.position, PosDisPisNormal.rotation);
            //intanciar la bala en la posicion en la cual esta rotando 
        }
    }
}
