using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

<<<<<<< HEAD
    public float mouseSensitivity = 1f;
=======
    public float mouseSensitivity = 100f;
>>>>>>> f595d60fbc689f486eaa3b19f930a7df87670e2c
    public Transform playerBody;

    float xRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   //Time.deltaTime is used so that mouseSensitivity is not dependent upon framerate(high sens when high framerate).
<<<<<<< HEAD
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity; //* Time.deltaTime; it is already time dependent
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity; //* Time.deltaTime;      ||       ||
=======
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
>>>>>>> f595d60fbc689f486eaa3b19f930a7df87670e2c

        // if xRotation += mosueY is used then camera will be inverted for y-axis.
        xRotation -= mouseY;
        // Mathf.Clamp takes three arguements and it will take the float value, minimum and maximum float value respectively.
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        // transfom is used to access position, rotation and scale of an object.
        // localRotation is rotation relative to the parent.
        // quaternions are 4dimensional, do not get gimbal lock and use shortest path. Quaternion.Euler means converting Euler angles to quaternion angles.
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);


        // player character should rotate when mouse is moved horizontally(y-axis).
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
