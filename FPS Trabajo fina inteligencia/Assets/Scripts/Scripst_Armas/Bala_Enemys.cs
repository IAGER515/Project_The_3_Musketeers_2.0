using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Enemys : MonoBehaviour {
    public float VelBala = 10f;
    public Vector3 Player;
    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        Player = player.transform.position;
        transform.Translate(Vector3.forward * VelBala * Time.deltaTime);
    }
}
