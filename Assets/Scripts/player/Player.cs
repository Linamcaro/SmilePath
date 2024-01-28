using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //movement variables
    private CharacterController characterController;
    [Header("movement")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject enemy;
    public bool inMove = true;
    private Vector3 move = Vector3.zero;
    [SerializeField] private Transform pos;
    [SerializeField] private Animator animator;
    


    [Header("camera")]
    //camera variables
    [SerializeField] private Camera cam;
    [SerializeField] float vMouseHorizontal;
    [SerializeField] float vMouseVertical;
    [SerializeField] float minRotate;
    [SerializeField] float maxRotate;
    [SerializeField] float h_mouse, v_mouse;
    [SerializeField] float timer;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
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
            movement();
            camera();
        } 
    }

    public void movement()
    {
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = transform.TransformDirection(move) * runSpeed;
            }
            else
            {
                move = transform.TransformDirection(move) * walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;
            }
            
        }

        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }

    public void camera()
    {
        h_mouse = vMouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += vMouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotate, maxRotate);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);
        transform.Rotate(0, h_mouse, 0);
    }
}
