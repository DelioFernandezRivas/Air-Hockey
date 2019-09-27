using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControladorInicio : MonoBehaviour
{

    public float tiempobien;
    public GameObject botonreanudar;
    public GameObject botonsalir;
    public KeyCode tecla;
    void Start()
    {
        if (botonreanudar.activeSelf == true && botonsalir.activeSelf == true)
        {

            botonreanudar.SetActive(false);
            botonsalir.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        tiempobien = Time.timeScale;
        
    }
    public void Cargarescena(string escena)
    {
        SceneManager.LoadScene(escena);



    }
    public void salirjuego() {

        Application.Quit();

    }
    public void reanudar()
    {
        botonreanudar = GameObject.Find("Reanudar2");
        botonsalir = GameObject.Find("SalirMenu2");
        botonreanudar.SetActive(false);
        botonsalir.SetActive(false);
        Time.timeScale = 1;
    }

    public void irmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Inicio");

    }


    void Update()
    {
        if (Input.GetKey(tecla))
        {
            
            botonreanudar.SetActive(true);
            botonsalir.SetActive(true);
            Time.timeScale = 0f;

        }
    }

}
