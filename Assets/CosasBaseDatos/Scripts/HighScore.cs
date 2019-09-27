using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System;

class HighScore {

    public string jugadores { get; set; }
    public int goles { get; set; }
    public int partidos { get; set; }



    public HighScore(string Jugadores, int Goles, int Partidos) {
        this.jugadores = Jugadores;
        this.goles = Goles;
        this.partidos = Partidos;



    }
}


