using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float movementSpeed;
    public float sensivity;
    public Transform[] celestials;

    Vector3 horizontalInput;
    Vector3 verticalInput;
    Vector3 inputVector;

    float mouseX;
    float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {

        if (Input.mouseScrollDelta.y > 0) movementSpeed = movementSpeed * 11 / 10;
        if (Input.mouseScrollDelta.y < 0) movementSpeed = movementSpeed * 10 / 11;

        horizontalInput = Input.GetAxisRaw("Horizontal") * transform.right;
        verticalInput = Input.GetAxisRaw("Vertical") * transform.forward;
        inputVector = (horizontalInput + verticalInput).normalized;
        transform.position += inputVector * movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.E)) transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) transform.position -= Vector3.up * movementSpeed * Time.deltaTime;

        mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX, Space.World);
        transform.Rotate(Vector3.left * mouseY, Space.Self);

        if (Input.GetKey(KeyCode.Alpha0)) follow(0);
        if (Input.GetKey(KeyCode.Alpha1)) follow(1);
        if (Input.GetKey(KeyCode.Alpha2)) follow(2);
        if (Input.GetKey(KeyCode.Alpha3)) follow(3);
        if (Input.GetKey(KeyCode.Alpha4)) follow(4);
        if (Input.GetKey(KeyCode.Alpha5)) follow(5);
        if (Input.GetKey(KeyCode.Alpha6)) follow(6);
        if (Input.GetKey(KeyCode.Alpha7)) follow(7);
        if (Input.GetKey(KeyCode.Alpha8)) follow(8);
        if (Input.GetKey(KeyCode.Alpha9)) follow(9);

    }

    public void follow(int index)
    {
        Vector3 direction = (celestials[0].position - celestials[index].position).normalized;
        if (index == 0) direction = -celestials[index].forward;
        Vector3 offset = direction * celestials[index].localScale.x * 20f;
        transform.position = celestials[index].position + offset;
        transform.LookAt(celestials[index]);
    }



}

