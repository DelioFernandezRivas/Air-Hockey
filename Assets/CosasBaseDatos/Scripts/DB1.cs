using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DB1 : MonoBehaviour
{


    public Con1 juegoctrl;






    void Start()
    {
        crearlatabla();
    }
    public void insertar(string jugador, int goles, int partidos)
    {
        string conn = "URI=file:" + Application.dataPath + "DB.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = string.Format("INSERT INTO Ranking (Jugadores,Golesmarcados,Partidosganados) values(\"{0}\",\"{1}\",\"{2}\")", jugador, goles, partidos);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteScalar();

        Debug.Log("Insertado");



        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    public void actualizargoles(int golesmarcados, string jugadores)
    {

        string conn = "URI=file:" + Application.dataPath + "DB.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = string.Format("UPDATE Ranking set  Golesmarcados =\"{0}\"WHERE Jugadores =\"{1}\" ", golesmarcados, jugadores);
        Debug.Log("String:" + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteScalar();

        Debug.Log("Actualizado");



        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;



    }

    public void actualizarpartidos(int partidosganados, string jugadores)
    {

        string conn = "URI=file:" + Application.dataPath + "DB.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = string.Format("UPDATE Ranking set  Partidosganados =\"{0}\" WHERE Jugadores =\"{1}\" ", partidosganados, jugadores);
        Debug.Log("String:" + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteScalar();

        Debug.Log("Actualizado");



        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;



    }

    public void crearlatabla()
    {
        string conn = "URI=file:" + Application.dataPath + "DB.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "CREATE TABLE if not exists Ranking (Jugadores TEXT NULL,Golesmarcados INTEGER NULL,Partidosganados INTEGER NULL,Juegosganados INTEGER NULL)";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }


}
