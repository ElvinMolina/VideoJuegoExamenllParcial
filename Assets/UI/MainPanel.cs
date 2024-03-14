using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainPanel : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject nombreJuego;

    public void Start()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
        nombreJuego.SetActive(true);

    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Creditos()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
        nombreJuego.SetActive(false);

    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
    
    public void VolverMenu()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
        nombreJuego.SetActive(true);

    }
}

