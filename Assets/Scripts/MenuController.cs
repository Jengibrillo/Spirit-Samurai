using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas
using UnityEngine.UI; // Necesario para trabajar con UI

public class MenuController : MonoBehaviour

{
    public void OnClickStartButton()
    {
        // Cambia a la escena del Nivel 1
        SceneManager.LoadScene("Level1");
    }

    public void OnClickOptionsButton()
    {
        // Cambia a la escena de Opciones
        SceneManager.LoadScene("Options");
    }

    public void OnClickQuitButton()
    {
        // Sale del juego
        Application.Quit();
    }
}
