using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float speedRotation = 20f;
    public Transform pivote;


    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(pivote.transform.position,Vector3.up,speedRotation*Time.deltaTime);
    }
}
