using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityValue;
    public bool inMove = true;
    private bool jump;
    private bool run;
    private Vector3 movement;

    private Transform cameraTransform;


    private void Start()
    {
        Cursor.visible = false; // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        controller = gameObject.GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

    }

    void Update()
    {

        if (!inMove)
        {
            walkSpeed = 0;
            runSpeed = 0;

        }
        else
        {
            walkSpeed = 5;
            runSpeed = 9;
            GetInput();
            Movement();
        }
    }

    /// <summary>
    /// Gather players input
    /// </summary>
    private void GetInput()
    {
        movement = InputManager.Instance.GetPlayerMovement();
        jump = InputManager.Instance.PlayerJumped();
        run = InputManager.Instance.PlayerRun();

    }

    private void Movement()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraTransform.forward * move.z +cameraTransform.right * move.x;
        move.y = 0;
        

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if(run)
        {
            controller.Move(move * Time.deltaTime * runSpeed);

            Debug.Log("Player running");

        }
        else 
        { 
            controller.Move(move * Time.deltaTime * walkSpeed);
        }
        // Changes the height position of the player..
        if (jump && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
