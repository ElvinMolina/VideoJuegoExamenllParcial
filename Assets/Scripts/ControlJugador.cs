using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public int muertes = 0; // Variable para contar las muertes
    public Transform respawnPoint; // Punto de reaparici�n del jugador
    public int maxMuertes = 3; // N�mero m�ximo de muertes antes de terminar el juego
    public Text muertesText; // Texto para mostrar el recuento de muertes

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Reiniciar manualmente para pruebas (opcional)
        {
            Morir();
        }
    }

    public void Morir()
    {
        muertes++; // Incrementar el recuento de muertes
        if (muertesText != null) // Actualizar el texto de las muertes
        {
            muertesText.text = "Muertes: " + muertes.ToString();
        }

        if (muertes >= maxMuertes) // Comprobar si se alcanz� el l�mite de muertes
        {
            Debug.Log("�Has perdido! Tres muertes."); // Mensaje de depuraci�n
            // Aqu� puedes implementar la l�gica para terminar el juego, como cargar un men� de juego perdido o reiniciar la escena
            return;
        }

        // Reiniciar el jugador
        transform.position = respawnPoint.position;
        Debug.Log("El jugador ha muerto. Reiniciando...");
    }
}
