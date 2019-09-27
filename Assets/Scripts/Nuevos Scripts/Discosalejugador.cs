using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discosalejugador : MonoBehaviour
{
    public int  numeroaleatoriosaque;
    public int numeroaleatorio;
    public GameObject Jugador1;
    public GameObject Jugador2;
    public Vector3 distancia1;
    public Vector3 distancia2;
    public Con1 juegoctrl;
    public KeyCode teclasacarjugador1;
    public KeyCode teclasacarjugador2;
    public bool sacarjugador1;
    public bool sacarjugador2;
    public Vector3 saque;
    public Vector3 posicioninicial;
    public Quaternion posicioninicialrotation;
    public Vector3 vectorpelota;
    public Rigidbody velocidadrigibody;
    public Vector3 velocidadminima;
    public float distanciadelbalon;
    public DB1 dbctrl;
    public GameObject mesa;
    public AudioSource sonidoAudiosourcejugador1;
    public AudioSource sonidoAudiosourcejugador2;


    void Awake()
    {
        vectorpelota = new Vector3(Random.Range(2f, 3f), 0f, Random.Range(2f, 3f));
        mesa = GameObject.Find("AirHockeyTable");
       
    }
    void Start()
    {
        distanciadelbalon = 0.25f;
        velocidadminima = new Vector3(0.5f, 0f, 0.5f);
        posicioninicial = transform.position;
        numeroaleatoriosaque = Random.Range(0, 2);
        saque = new Vector3(Random.Range(2f, 3f), 0f, Random.Range(2f, 3f));
        sacarjugador1 = false;
        sacarjugador2 = false;
        posicioninicialrotation = transform.rotation;
        if (juegoctrl.terminajuego == false)
        {
            if (numeroaleatoriosaque == 0)
                StartCoroutine(espera3segundosJugador1());

            if (numeroaleatoriosaque == 1)
            {
                StartCoroutine(espera3segundosJugador2());
            }
        }


    }

    void FixedUpdate()

    {
        distancia1 = new Vector3(Jugador1.transform.position.x+ -distanciadelbalon, 1.7f, Jugador1.transform.position.z);
        distancia2 = new Vector3(Jugador2.transform.position.x+(distanciadelbalon), 1.7f, Jugador2.transform.position.z);
        if (Input.GetKey(teclasacarjugador1)&& sacarjugador1==true) {
            gameObject.GetComponent<Rigidbody>().velocity = -saque;
            gameObject.transform.SetParent(null);
            sacarjugador1 = false;
            


        }
        if (Input.GetKey(teclasacarjugador2)&&sacarjugador2==true) {
            gameObject.GetComponent<Rigidbody>().velocity = saque;
            gameObject.transform.SetParent(null);
            sacarjugador2 = false;
            
        }
        if (juegoctrl.terminajuego == true)
        {
            StopAllCoroutines();
            posicionreferencia();
            velocidadrigibody.velocity = new Vector3(0f, 0f, 0f);


        }
    }

    public void posicion1()
    {
        transform.position = distancia1;
        posicioninicialrotation = gameObject.transform.rotation;
        gameObject.transform.SetParent(Jugador1.transform);
        sacarjugador1 = true;

        


    }
    public void posicion2()
    {
        transform.position = distancia2;
        posicioninicialrotation = gameObject.transform.rotation;
        gameObject.transform.SetParent(Jugador2.transform);
        sacarjugador2 = true;
        

    }
    public IEnumerator espera3segundosJugador1()
    {
        yield return new WaitForSeconds(3f);
        posicion1();



    }

    public IEnumerator espera3segundosJugador2()
    {
        yield return new WaitForSeconds(3f);
        posicion2();



    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Caja1")
        {
            posicionreferencia();
            juegoctrl.goles2++;
            juegoctrl.marcargoljugador2();
            velocidadrigibody.velocity = new Vector3(0f, 0f, 0f);
            sonidoAudiosourcejugador2.Play();
            StartCoroutine(espera3segundosJugador1());
            dbctrl.actualizargoles(juegoctrl.goles2, juegoctrl.jugador2string);







        }
        if (other.gameObject.tag == "Caja2")
        {
            posicionreferencia();
            juegoctrl.goles1++;
            juegoctrl.marcargoljugador1();
            velocidadrigibody.velocity = new Vector3(0f, 0f, 0f);
            sonidoAudiosourcejugador1.Play();
            StartCoroutine(espera3segundosJugador2());
            dbctrl.actualizargoles(juegoctrl.goles1, juegoctrl.jugador1string);


        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            GetComponent<Rigidbody>().velocity = -vectorpelota;

        }
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Ia")
        {
            GetComponent<Rigidbody>().velocity = vectorpelota;

        }
        if (collision.gameObject.tag == "MesaColisiones") {
            gameObject.GetComponent<AudioSource>().Play();


        }
    }
     void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.MoveTowards(gameObject.transform.position,mesa.transform.position,0f));

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mesa")
        {
            Saquealeatorio();

        }
    }

    public void Saquealeatorio()
    {
        velocidadrigibody.velocity = new Vector3(0f, 0f, 0f);
        posicionreferencia();
        numeroaleatorio = Random.Range(0, 2);
        if (numeroaleatorio == 0)
        {
            StartCoroutine(espera3segundosJugador1());
            sacarjugador1 = true;
            
        }
        if (numeroaleatorio == 1)
        {

            StartCoroutine(espera3segundosJugador2());
            sacarjugador2 = true;
            
        }
    }

    public void posicionreferencia()
    {
        transform.position = posicioninicial;
        transform.rotation = posicioninicialrotation;
    }

    public void velocidadminimametodo()
    {
       
            posicionreferencia();
            velocidadrigibody.velocity = new Vector3(0f, 0f, 0f);
            numeroaleatorio = Random.Range(0, 2);
            if (numeroaleatorio == 0 && sacarjugador1==true)
                StartCoroutine(espera3segundosJugador1());
                sacarjugador1 = true;
            if (numeroaleatorio == 1 && sacarjugador1 == true)
            {

                StartCoroutine(espera3segundosJugador2());
                sacarjugador2 = true;
            }


        

    }


}
