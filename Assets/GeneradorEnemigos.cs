using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject characterPrefab; // El prefab del personaje que deseas instanciar
    public int groupCount = 10; // Número de grupos que deseas generar
    public float spacing = 35f; // Espaciado entre personajes metros
    public Vector3 planeSize = new Vector3(2f, 1f, 1f); // Size of the plane

    void Start()
    {
        GenerateGroups();
    }

    void GenerateGroups()
    {
        float halfWidth = planeSize.x / 2f;
        float halfLength = planeSize.z / 2f;

        for (int i = 0; i < groupCount; i++)
        {
            Vector3 groupPosition = new Vector3(Random.Range(-halfWidth, halfWidth), 12f, Random.Range(-halfLength, halfLength)); // Posición aleatoria en el plano
            GenerateGroup(groupPosition);
        }
    }

    void GenerateGroup(Vector3 groupPosition)
    {
        for (int i = 0; i < 3; i++)
        {
            //Instantiate(characterPrefab, new Vector3(0, 12, 0), Quaternion.identity);

            Vector3 offset = new Vector3(Random.Range(-spacing, spacing), 0f, Random.Range(-spacing, spacing)); // Desplazamiento aleatorio dentro del espaciado
            Vector3 spawnPosition = groupPosition + offset;
            Instantiate(characterPrefab, spawnPosition, Quaternion.identity); // Instanciar personaje en la posición calculada
        }
    }
}
