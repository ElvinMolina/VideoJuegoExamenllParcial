using UnityEngine;
using UnityEngine.UI;

public class LogicaGolpeEnemigo : MonoBehaviour
{
    public int hpMax;
    public int dañoPuñoMax;
    public Animator anim;

    // Referencia al objeto de texto dentro del Canvas
    public Text hpText;

    void Update()
    {
        if (hpText != null) // Asegúrate de que el objeto de texto no sea nulo
        {
            hpText.text = "Vida: " + hpMax.ToString(); // Actualiza el texto con la vida restante
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GolpeImpactoEnemigo")
        {
            // Reducir la HP por el daño recibido
            hpMax -= dañoPuñoMax;

            // Si la HP es menor o igual a cero, destruir el objeto
            if (hpMax <= 0)
            {
                DestruirObjeto();
            }
        }
    }

    // Método para destruir el objeto
    void DestruirObjeto()
    {
        // Asegurarse de que el objeto aún existe antes de destruirlo
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
