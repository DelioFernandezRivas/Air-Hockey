using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discofunciona : MonoBehaviour
{
    public float velocidadx;
    public float velocidadz;
    private float velocidad = 3f;
    public Vector3 vectorpelota;
    public Con1 juegoctrl;
    public Vector3 posicioninicial;
    public Quaternion posicioninicialrotation;
    public Rigidbody velocidadparar;
    public Vector3 velocidadactual;
    public Vector3 velocidadminima;
    public Vector3 posicionpruevas;
    void Start()
    {
        posicionpruevas = new Vector3(0f, 0f, 0f);
        posicioninicial = transform.position;
        posicioninicialrotation = transform.rotation;
        vectorpelota = new Vector3(Random.Range(2f, 3f), 0f, Random.Range(2f, 3f));
        StartCoroutine(espera3segundos());
        velocidadminima = new Vector3(1, 0, 1);
    }
    void Update()
    {
        //posicionpruevas = GetComponent<Rigidbody>().position;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
           GetComponent<Rigidbody>().velocity = vectorpelota;

        }
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag== "Caja1")
        {
            juegoctrl.goles2++;
            juegoctrl.marcargoljugador2();
            velocidadparar.velocity = new Vector3(0f, 0f, 0f);
            posicionreferencia();
            iniciarcorrutina();






        }
        if (other.gameObject.tag == "Caja2")
        {
            juegoctrl.goles1++;
            juegoctrl.marcargoljugador1();
            velocidadparar.velocity = new Vector3(0f, 0f, 0f);
            posicionreferencia();
            iniciarcorrutina();
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mesa")
        {
            velocidadparar.velocity = new Vector3(0f, 0f, 0f);
            posicionreferencia();
            iniciarcorrutina();


        }
    }

    public IEnumerator espera3segundos()
    {
        yield return new WaitForSeconds(3f);
        movimientoairhokeypuck();



    }

    public void iniciarcorrutina() {
        StartCoroutine(espera3segundos());
    }

    public void posicionreferencia()
    {
        transform.position = posicioninicial;
        transform.rotation = posicioninicialrotation;
    }

    public void movimientoairhokeypuck()
    {
        velocidadx = Random.Range(-2f, 2f);

        if (velocidadx > 0)
        {
            velocidadx = 1;
        }
        else
        {
            velocidadx = -1;
        }
        velocidadz = Random.Range(-2f, 2f);

        if (velocidadz > 0)
        {
            velocidadz = 1;
        }
        else
        {
            velocidadz = -1;
        }

        velocidadparar = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().velocity = new Vector3(velocidad * velocidadx, 0, velocidad * velocidadz);
    }
}

