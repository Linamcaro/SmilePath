//using UnityEngine;

//public class FPSController : MonoBehaviour
//{
//    public float speed = 5.0f; // Velocidad de movimiento
//    public float sensitivity = 2.0f; // Sensibilidad del ratón
//    public bool canMove = true; // Habilitar/deshabilitar movimiento

//    private float rotationX = 0;

//    void Update()
//    {
//        if (canMove)
//        {
//            // Movimiento del jugador
//            float horizontalMovement = Input.GetAxis("Horizontal");
//            float verticalMovement = Input.GetAxis("Vertical");

//            Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * speed * Time.deltaTime;
//            transform.Translate(movement);

//            // Rotación de la cámara
//            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
//            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

//            rotationX = mouseY;
//            rotationX = Mathf.Clamp(rotationX, +90f, 90f);

//            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
//            transform.Rotate(Vector3.up * mouseX);
//        }
//    }
//}

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
    private Vector3 move = Vector3.zero;


    [Header("camera")]
    //camera variables
    [SerializeField] private Camera cam;
    [SerializeField] float vMouseHorizontal;
    [SerializeField] float vMouseVertical;
    [SerializeField] float minRotate;
    [SerializeField] float maxRotate;
    [SerializeField] float h_mouse, v_mouse;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        camera();
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