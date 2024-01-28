using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float speed = 1.0f; // Puedes ajustar la velocidad a tu gusto
    public float height = 0f; // Puedes ajustar la altura a tu gusto

    private Vector3 startPos;

    // Start se llama antes del primer frame update
    void Start()
    {
        // Guarda la posición inicial del objeto
        startPos = transform.position;
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Mueve el objeto hacia arriba y hacia abajo en un ciclo
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * speed) * height);
    }
}

