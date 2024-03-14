using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public int muertes = 0; // Variable para contar las muertes
    public Transform respawnPoint; // Punto de reaparición del jugador
    public int maxMuertes = 3; // Número máximo de muertes antes de terminar el juego
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

        if (muertes >= maxMuertes) // Comprobar si se alcanzó el límite de muertes
        {
            Debug.Log("¡Has perdido! Tres muertes."); // Mensaje de depuración
            // Aquí puedes implementar la lógica para terminar el juego, como cargar un menú de juego perdido o reiniciar la escena
            return;
        }

        // Reiniciar el jugador
        transform.position = respawnPoint.position;
        Debug.Log("El jugador ha muerto. Reiniciando...");
    }
}
