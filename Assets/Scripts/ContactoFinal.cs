using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactoFinal : MonoBehaviour
{

      private Vector3 puntoInicio; // Punto de inicio del jugador

    void Start()
    {
        puntoInicio = transform.position; // 
    }
    // Update is called once per frame
    void Update()

    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ContactoFinal")
        {
            //transform.position = puntoInicio;

            SceneManager.LoadScene("MainMenu");
            // aquí solo tengo de ejemplo que si llega a la nave vuelve a inciar, pero realmente irá la llamada del menu
        }

     
    }
}
