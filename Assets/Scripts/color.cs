using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    public GameObject player;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            this.GetComponent<Renderer>().material.color = Color.cyan;
            player.transform.position = point.transform.position;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Input.GetKey(KeyCode.R))
            {
                
                other.transform.position = new Vector3(-1.56f, -4.78f, -24.32f);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
