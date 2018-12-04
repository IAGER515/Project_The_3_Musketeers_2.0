using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola_Escopeta : MonoBehaviour {
    public GameObject BalaEscopeta;//disparo del jugador escopeta
    public Transform PosisicionDisEscopeta;//posicion donde va a espaunear la bala                                   
    void Start () {
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Disparo Escopeta");
            Instantiate(BalaEscopeta, PosisicionDisEscopeta.position, PosisicionDisEscopeta.rotation);
            //intanciar la bala en la posicion en la cual esta rotando 
        }
    }
}
