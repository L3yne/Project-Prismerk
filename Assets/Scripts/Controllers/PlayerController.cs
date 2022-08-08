using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float lookSens = 3;
    public Vector3 jump;
    public float jumpForce = 3.0f;

    public bool isGrounded;
    Rigidbody rb; 
    private PlayerMotor motor;

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        
        //Calculate movement velocity as a 3D vector
        float xMove = Input.GetAxisRaw("Horizontal"); //from -1 to 1
        float zMove = Input.GetAxisRaw("Vertical");   //from -1 to 1

        Vector3 moveHorizontal = transform.right * xMove; // moving = ((+-1),   0,     0 )
        Vector3 moveVertical = transform.forward * zMove; // moving = (   0 ,   0,  (+-1))

        //Final movement vector
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        //Apply movement
        motor.Move(velocity);

        //Calculate rotation as a 3D vector: This applies to turning around
        float yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3 (0f, yRotation, 0f) * lookSens;

        //Apply rotation
        motor.Rotate(rotation);

        //Calculate camera rotation as a 3D vector
        float xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3 (xRotation, 0f, 0f) * lookSens;

        //Apply rotation
        motor.RotateCamera(cameraRotation);

        //Apply jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
