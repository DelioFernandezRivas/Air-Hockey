using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destruirycrearmusica : MonoBehaviour
{
    public Scene escenaprueva;

    private static Destruirycrearmusica destruismusica;

    void Awake()
    {

        

        DontDestroyOnLoad(gameObject);

        if (destruismusica==null) {
            destruismusica = this;
        }

        else {
            Destroy(gameObject);

        }


    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "ContraIa" || SceneManager.GetActiveScene().name == "ContralaIaDificil" || SceneManager.GetActiveScene().name == "Jugador contra Jugador")
        {
            Destroy(gameObject);
        }

    }
}