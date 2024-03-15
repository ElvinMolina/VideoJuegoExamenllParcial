using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject characterPrefab;
    public int groupCount = 10; // Número de grupos
    public float spacing = 35f; // Espaciado entre personajes metros

    void Start()
    {
        GenerateGroups();
    }

    void GenerateGroups()
    {
        for (int i = 0; i < groupCount; i++)
        {
            Vector3 groupPosition = new Vector3(Random.Range(-100f, 430f), 17f, Random.Range(-100f, 212f));
            //Vector3 groupPosition = new Vector3(Random.Range(-halfWidth, halfWidth), 8f, Random.Range(-halfLength, halfLength)); // Posición aleatoria en el plano
            GenerateGroup(groupPosition);
        }
    }

    void GenerateGroup(Vector3 groupPosition)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-spacing, spacing), 0f, Random.Range(-spacing, spacing)); // Desplazamiento aleatorio dentro del espaciado
            Vector3 spawnPosition = groupPosition + offset;
            Instantiate(characterPrefab, spawnPosition, Quaternion.identity); // Instanciar personaje en la posición calculada
        }
    }
}
