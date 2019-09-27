using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Insertarjugador : MonoBehaviour
{

    public TMP_InputField Jugador1;
    public TMP_InputField Jugador2;
    public string jugador1;
    public string jugador2;
    public bool contralaia;
    void Start()
    {
        Jugador1 = GameObject.Find("Jugador1").GetComponent<TMP_InputField>();
        
        jugador1 = "";
      
        if(SceneManager.GetActiveScene().name == "Insertajugadorvsjugador")
        {
            Jugador2 = GameObject.Find("Jugador2").GetComponent<TMP_InputField>();
            jugador2 = "";

        }
    }
     void Update()
    {

        if (SceneManager.GetActiveScene().name == "Insertajugadorvsjugador" ||SceneManager.GetActiveScene().name == "InsertarjugadorvsIa" || SceneManager.GetActiveScene().name == "InsertarJugadorVsIaDificil")
        
            jugador1 = Jugador1.text;
        if (SceneManager.GetActiveScene().name == "Insertajugadorvsjugador")
        {

            jugador2 = Jugador2.text;

        }
        if (SceneManager.GetActiveScene().name=="Inicio")
        {

            Destroy(gameObject);
        }

    }


    public void cargarescena(string escena)
    {
        SceneManager.LoadScene(escena);


    }
    void Awake()
    {
      
        DontDestroyOnLoad(gameObject);

       
    }

    public void irmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Inicio");

    }


}

