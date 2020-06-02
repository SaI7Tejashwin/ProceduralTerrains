using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float speed = 20f;

    float xRotation = 0f;
    float yRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation -= mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0);

        CameraController();

    }

    void CameraController()
    {
        float h_I = Input.GetAxis("Horizontal");
        float v_I = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h_I + transform.forward * v_I;

        GetComponent<CharacterController>().Move(move * speed * Time.deltaTime);
    }
}
