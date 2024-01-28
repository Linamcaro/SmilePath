using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandomPosition : MonoBehaviour
{
    public List<Vector3> coordinates; // La lista de coordenadas a las que puedes mover el objeto

    // Start se llama antes del primer frame update
    void Start()
    {
        MoveToRandomCoordinate();
    }

    public void MoveToRandomCoordinate()
    {
        if (coordinates.Count > 0)
        {
            // Selecciona una coordenada aleatoria de la lista
            Vector3 randomCoordinate = coordinates[Random.Range(0, coordinates.Count)];
            Debug.Log("Coordenada"+randomCoordinate);
            // Mueve el objeto a la coordenada aleatoria
            transform.position = randomCoordinate;
        }
    }
}