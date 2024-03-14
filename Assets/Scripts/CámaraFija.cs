using UnityEngine;
using Cinemachine;

public class CamaraFija : MonoBehaviour
{
    public Transform objetivo; // El objeto que la cámara seguirá
    public Vector3 offset; // La distancia desde el objetivo

    private void LateUpdate()
    {
        // Actualizar la posición de la cámara
        transform.position = objetivo.position + offset;

        // Mantener la cámara mirando hacia el objetivo
        transform.LookAt(objetivo);
    }
}

