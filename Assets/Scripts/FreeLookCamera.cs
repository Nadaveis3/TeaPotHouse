using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float mouseSensitivity = 3f;
    public float zoomSpeed = 10f;
    public float minY = -90f;
    public float maxY = 90f;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        rotationX = eulerRotation.x;
        rotationY = eulerRotation.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * movementSpeed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * zoomSpeed * Time.deltaTime;
    }
}