﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_jugador : FPS_BasJugador
{
    public override void mecanicas()
    {
        if (EstadoActual == EstadoJugador.Mecanicas)
        {
            //se multiplica la velocidad para darle el movimiento con el raton en x
            movimientoHorizaontal = velocidadHorizontal * Input.GetAxis("Mouse X");
            //se multiplica la velocidad para darle el movimiento con el raton en x
            movimientoVertical = velocidadVertical * Input.GetAxis("Mouse Y");
            transform.Rotate(0, movimientoHorizaontal, 0);//rotacion de personaje en horizontal
            transform.Rotate(-movimientoVertical, 0, 0);//rotacion del personaje en vertical
            //movimiento de jugador
            Mira.transform.position = Input.mousePosition;
            //le damos la posicion del maouse para ver 
            FolloWeapont.transform.position = CamaraJugador.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.6f));
            //donde tiene que ver el arma
            currentWeapomt[0].transform.LookAt(FolloWeapont.transform.position);
            // currentWeapomt[1].transform.LookAt(FolloWeapont.transform.position);
            //cuando se presiona el boton se mouse se crea e raycast para detectat que el obj ha colisionado
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0f, 0f, 0.1f);
                //arriba
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0f, 0f, -0.1f);
                //abajo
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(0.1f, 0f, 0.1f);
                //izquierda
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-0.1f, 0f, 0f);
                //derecha
            }
            // if para el salto del jugador
            if (Input.GetKeyDown(KeyCode.Space) && saltar == true)
            {
                rbd.AddForce(Vector3.up * VelSalto);
                saltar = false;
            }
        }
        if (Input.GetKeyDown("e"))
        {
            PistolaNormal.SetActive(true);
            Escopeta2.SetActive(false);
        }
        if (Input.GetKeyDown("q"))
        {
            PistolaNormal.SetActive(false);
            Escopeta2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Piso")
        {
            saltar = true;
        }
        if (other.tag == "BulletEnemy" )
        {
            vidaPlayer = vidaPlayer-10;
        }
        if (other.tag == "EnemyCuerpo")
        {
            vidaPlayer = vidaPlayer-5;
        }
        if (vidaPlayer == 0)
        {
            muerte.SetActive(true);
            ButtonIniciar.SetActive(true);
        }
        
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        mecanicas();
    }
}
