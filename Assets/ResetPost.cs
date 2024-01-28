using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPost : MonoBehaviour
{
    public Transform transform;
    private GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            player.transform.position = transform.position;
            player.SetActive(true);
            Debug.Log("Wather");
        }
    }
}
