using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {
    public float VelBala = 10f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * VelBala *Time.deltaTime);
        //disparar en la posicion de la mira 
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyCuerpo")
        {
            Destroy(gameObject);
        }
    }
}
