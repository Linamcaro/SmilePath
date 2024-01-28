using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVFx : MonoBehaviour
{

    [SerializeField] private GameObject teleportParticles;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.inMove)
        {
            teleportParticles.SetActive(false);
        }
        else
        {
            teleportParticles.SetActive(true);
        }

    }


}
