using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaGolpeEnemigo : MonoBehaviour
{
    public int hpMax; // Vidas máximas
    public int cantvidas;
    public int dañoPuñoMax = 1; // Daño máximo por golpe
    public Animator anim;

    
    public Text hpText;

    
    public Text vidasText;
    private Vector3 puntoInicio; // Punto de inicio del jugador

    void Start()
    {
        cantvidas = 3;
        puntoInicio = transform.position; // Guarda la posición inicial del jugador
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
            // Reducir la HP por el daño recibido
            hpMax -= dañoPuñoMax;

            // Actualiza el texto de vida después de recibir el daño
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
           // SceneManager.LoadScene("MENU"); // ponga como se llama la escena aquí, el menú que hiciste
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
