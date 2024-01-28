
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion2 : MonoBehaviour
{
    public float speed = 1.0f; // La velocidad a la que el objeto debe moverse
    public float width = 1.0f; // El ancho del �valo
    public float height = 1.0f; // La altura del �valo

    private Vector3 startPos;

    // Start se llama antes del primer frame update
    void Start()
    {
        // Guarda la posici�n inicial del objeto
        startPos = transform.position;
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Calcula la nueva posici�n del objeto usando funciones de seno y coseno
        float x = width * Mathf.Cos(Time.time * speed);
        float y = height * Mathf.Sin(Time.time * speed);
        transform.position = startPos + new Vector3(x, 0, y);
    }
}
