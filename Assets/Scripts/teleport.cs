using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class teleport : MonoBehaviour
{

    [SerializeField] private float disTeleport = 6;
    [SerializeField] private Animator animator;
    public Transform telpoint;
    public GameObject player;

    public event EventHandler StopPatrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position,transform.forward);
        Debug.DrawRay(ray.origin + Vector3.up, ray.direction * disTeleport);
        if (Physics.Raycast(ray, out hit,disTeleport))
        {
            if (hit.collider.CompareTag("Player"))
            {
                animator.SetBool("isRunning",false);
                animator.SetBool("isWalking",false);
                animator.SetBool("isTeleporting",true);
                StopPatrol.Invoke(this, EventArgs.Empty);
                hit.collider.GetComponent<player>().inMove = false;
                Debug.Log("hit");
                //hit.transform.position = telpoint.transform.position;
            }
        }
    }
    
}
 