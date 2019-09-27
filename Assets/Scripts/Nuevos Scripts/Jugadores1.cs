using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores1 : MonoBehaviour
{
    public KeyCode tecla1;
    public KeyCode tecla2;
    public KeyCode tecla3;
    public float velocidad = 2f;
    public Vector3 vecorvelocidad;
    public int puntuacion = 0;
    public Vector3 Vectorfinal;
    public Vector3 Vectorfinal2;
    public Rigidbody JugadorRigidbody;
    public int tiempo = 5;
    public Con1 Controljuego;
  


    void Start()
    {
        
        vecorvelocidad = new Vector3(0f,0f,5)*velocidad;
        JugadorRigidbody = gameObject.GetComponent<Rigidbody>();
        Vectorfinal.z = 0.50f;
        Vectorfinal2.z = -0.50f;
        
    }

    void FixedUpdate()
    {
        if (Controljuego.terminajuego == false&& (Vectorfinal.z >= JugadorRigidbody.position.z))
        {
            if (Input.GetKey(tecla1))
            {

                transform.Translate(0f, 0f, 5f*velocidad * Time.deltaTime);
                


            }
        }
        if (Controljuego.terminajuego == false && (Vectorfinal2.z <= JugadorRigidbody.position.z))
        {
            if (Input.GetKey(tecla2))
            {

                transform.Translate(0f, 0f, 5f*-velocidad * Time.deltaTime);
                



            }
        }
       

    }


}
