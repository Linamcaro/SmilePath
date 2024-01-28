using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPost : MonoBehaviour
{
    [SerializeField] Transform transform;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = transform.position;
            Debug.Log("Wather");
        }
    }
}
