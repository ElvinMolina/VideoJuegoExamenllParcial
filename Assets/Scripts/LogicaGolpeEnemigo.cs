using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaGolpeEnemigo : MonoBehaviour
{
    public int hpMax; // Vidas m�ximas
    public int cantvidas;
    public int da�oPu�oMax = 1; // Da�o m�ximo por golpe
    public Animator anim;

    
    public Text hpText;

    
    public Text vidasText;
    private Vector3 puntoInicio; // Punto de inicio del jugador

    void Start()
    {
        cantvidas = 3;
        puntoInicio = transform.position; // Guarda la posici�n inicial del jugador
        ActualizarTextoVida();
        ActualizarTextoVidasPerdidas();
    }

    void ActualizarTextoVida()
    {
        if (hpText != null)
        {
            hpText.text = "Vida: " + hpMax.ToString()+" %  / Vidas Restantes: " + cantvidas.ToString(); // Actualiza el texto con las vidas restantes
        }
    }

    void ActualizarTextoVidasPerdidas()
    {
        if (vidasText != null)
        {
            vidasText.text = " " + cantvidas.ToString(); // Actualiza el texto con las vidas perdidas
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GolpeImpactoEnemigo")
        {
            // Reducir la HP por el da�o recibido
            hpMax -= da�oPu�oMax;

            // Actualiza el texto de vida despu�s de recibir el da�o
            ActualizarTextoVida();

            // Si la HP es menor o igual a cero, destruir el objeto
            if (hpMax == 0)
            {
                PerderVida();
            }
        }
    }

    void PerderVida()
    {
        cantvidas--; // Incrementa el contador de vidas perdidas
        if (cantvidas == 0)
        {
           // SceneManager.LoadScene("MENU"); // ponga como se llama la escena aqu�, el men� que hiciste
        }
        else
        {
            // volver al punto inicial
            transform.position = puntoInicio;
            hpMax = 1; // darle la vida de nuevo
            ActualizarTextoVida();
            ActualizarTextoVidasPerdidas();
        }
    }
}
