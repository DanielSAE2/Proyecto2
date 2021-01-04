using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    //Carga la pantalla del circuito
    public void Fishdex()
    {
        SceneManager.LoadScene(1);
    }

    //Carga la pantalla del menu
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Carga la partida
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    //Cierra el juego
    public void Exit()
    {
        Application.Quit();
    }
}
