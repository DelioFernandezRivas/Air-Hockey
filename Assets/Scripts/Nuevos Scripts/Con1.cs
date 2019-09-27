using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Con1 : MonoBehaviour
{
    public int goles1;
    public int goles2;
    public int partidas1;
    public int partidas2;
    public TextMeshProUGUI golesjugador1text;
    public TextMeshProUGUI golesjugador2text;
    public TextMeshProUGUI partidostext;
    public TextMeshProUGUI findeljuego;
    public Discosalejugador discoctrl;
    public float segundos;
    public string jugador1string;
    public string jugador2string;
    public GameObject ia;
    public bool terminajuego;
    public Insertarjugador insertarctrl;
    public GameObject Global;
    public DB1 dbctrl;
    public AudioSource musicacontrolador;
    public AudioClip partidoganadomusica;
    public AudioClip juegoganadomusica;
    void Start()
    {
        Global = GameObject.Find("ControladorInsertar");
        insertarctrl = Global.gameObject.GetComponent<Insertarjugador>();
        jugador1string = insertarctrl.jugador1;
        golesjugador1text.text = jugador1string + ": " + goles1;
        musicacontrolador = GameObject.Find("Musicacontrolador").GetComponent<AudioSource>();



        if (ia = GameObject.Find("Ia")) {
            jugador2string = "IA";
            golesjugador2text.text = jugador2string + ": " + goles1;

        }
        else
        {
            jugador2string = insertarctrl.jugador2;
            golesjugador2text.text = jugador2string + ": " + goles1;
            dbctrl.insertar(jugador2string, 0, 0);

        }
            segundos = 3f;
        goles1 = 0;
        goles2 = 0;
        partidas1 = 0;
        partidas2 = 0;
        terminajuego = false;
        dbctrl.insertar(jugador1string, 0, 0);
    }



  
    void FixedUpdate()
    {
        
        if (goles1 == 5 || goles2 == 5)
        {
            ganarpartido();

        }
        if (partidas1 == 3 || partidas2 == 3)
        {
            ganarjuego();
            StartCoroutine(salirmenu());
                }
    }
    

    public void marcargoljugador1()
    {
        
            golesjugador1text.text = jugador1string + ": " + goles1;
        
        

    }
    public void marcargoljugador2()
    {
        if (ia = GameObject.Find("Ia")) {

            golesjugador2text.text = "Ia Puntuación: " + goles2;

        }




        else
        {
            golesjugador2text.text = jugador2string + ": " + goles2;

        }

    }

    public void ganarpartido()
    {


        if (goles1 == 5)
        {
            if (partidas1 < 2)
            {
                partidostext.text = "Gana "+ jugador1string;
                //dbctrl.actualizar(5,0,"Delio");
                //dbctrl.borrar("Delio");
                musicacontrolador.PlayOneShot(partidoganadomusica, 0.7f);
                StartCoroutine(empezarsiguientepartida());

            }
            partidas1++;
            dbctrl.actualizarpartidos(partidas1, jugador1string);
        }
        if (goles2 == 5)
        {
            if (partidas2 < 3)
            {
                if (ia = GameObject.Find("Ia")) {

                    partidostext.text = "Gana la Ia";
                    musicacontrolador.PlayOneShot(partidoganadomusica, 0.7f);
                    StartCoroutine(empezarsiguientepartida());
                    partidas2++;
                }

                else
                {
                    partidostext.text = "Gana "+ jugador2string;
                    dbctrl.actualizarpartidos(partidas2, jugador2string);
                    musicacontrolador.PlayOneShot(partidoganadomusica, 0.7f);
                    StartCoroutine(empezarsiguientepartida());
                    partidas2++;
                    dbctrl.actualizarpartidos(partidas2, jugador2string);

                }
            }
         

        }
            
            goles1 = 0;
            goles2 = 0;
            golesjugador1text.text = jugador1string + ": " + goles1;
            golesjugador2text.text = jugador2string + ": " + goles2;
        

        //musicacontrolador.PlayOneShot(partidoganadomusica, 0.7f);
        discoctrl.Saquealeatorio();











    }

    public void ganarjuego()
    {

        if (partidas1 == 3)
        {
            findeljuego.text = "Gana el juego " + jugador1string;
        }
        else
        {
            if (ia = GameObject.Find("Ia"))
            {
                findeljuego.text = "Gana el juego la Ia";

            }

            else
            {
                findeljuego.text = "Gana el juego " + jugador2string;
            }

        }
        musicacontrolador.PlayOneShot(juegoganadomusica, 0.7f);
        terminajuego = true;
        Time.timeScale = 1;
        


    }


    
    IEnumerator empezarsiguientepartida()
    {
        yield return new WaitForSeconds(2f);
        partidostext.text = "";
    }


    IEnumerator salirmenu() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Inicio");

    }
    
    
}

   
