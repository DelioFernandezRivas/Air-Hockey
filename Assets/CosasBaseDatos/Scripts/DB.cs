using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class DB : MonoBehaviour
{
    public Con1 juegoctrl;

    private List<HighScore> highscores = new List<HighScore>();

    public GameObject scorePrefap;

    public Transform scoreparent;
    private string[] jugadores;
    void Start()
    {
        
        leerdatos();
        showscores();


    }


    

    public void leerdatos()
    {
        string conn = "URI=file:" + Application.dataPath + "DB.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Jugadores,Golesmarcados, Partidosganados,Juegosganados " + "FROM Ranking";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string jugadores = reader.GetString(0);
            int goles = reader.GetInt32(1);
            int partidos = reader.GetInt32(2);

            highscores.Add(new HighScore(jugadores, goles, partidos));
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }



    public void borrar(string jugador)
    {

        string conn = "URI=file:" + Application.dataPath + "DB.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = string.Format("Delete from Ranking WHERE Jugadores=\"{0}\"", jugador);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteScalar();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    private void showscores()
    {
        for (int i = 0; i < highscores.Count; i++)
        {
            GameObject tmobjet = Instantiate(scorePrefap);

            HighScore tmpscore = highscores[i];
            tmobjet.GetComponent<HighScoreScript>().setscore(tmpscore.jugadores,tmpscore.goles.ToString(),tmpscore.partidos.ToString());

            tmobjet.transform.SetParent(scoreparent);

        }

    }
    //public string[] Leerdjugador() {
    //    string conn = "URI=file:" + Application.dataPath + "/CosasBaseDatos/DB.s3db"; //Path to database.
    //    IDbConnection dbconn;
    //    dbconn = (IDbConnection)new SqliteConnection(conn);
    //    dbconn.Open(); //Open connection to the database.
    //    IDbCommand dbcmd = dbconn.CreateCommand();
    //    string sqlQuery = "SELECT Jugadores,Golesmarcados, Partidosganados,Juegosganados " + "FROM Ranking";
    //    dbcmd.CommandText = sqlQuery;
    //    IDataReader reader = dbcmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        for (int i = 0; i<10; i++) {
    //            string jugadoresmeter = reader.GetString(0);
    //            jugadoresmeter = jugadores[i];
    //        return jugadores;
    //        }
    //    }
    //    reader.Close();
    //    reader = null;
    //    dbcmd.Dispose();
    //    dbcmd = null;
    //    dbconn.Close();
    //    dbconn = null;
        


    //}
}
