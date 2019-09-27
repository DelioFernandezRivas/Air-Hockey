using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HighScoreScript : MonoBehaviour
{

    public GameObject Jugadores;
    public GameObject Goles;
    public GameObject partidos;

    public void setscore(string jugadores,string goles,string partidos) {
        this.Jugadores.GetComponent<Text>().text = jugadores;
        this.Goles.GetComponent<Text>().text = goles;
        this.partidos.GetComponent<Text>().text = partidos;


    }
     
  
}
