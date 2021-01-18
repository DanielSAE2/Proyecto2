using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    
    //Carga la pantalla del menu
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Carga la partida
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    //Carga la pantalla de la Fishdex
    public void Fishdex()
    {
        SceneManager.LoadScene(2);
    }

    //Carga las opciones
    public void Options()
    {
        SceneManager.LoadScene(3);
    }

    //Cierra el juego
    public void Exit()
    {
        Application.Quit();
    }
}
