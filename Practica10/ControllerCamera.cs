using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public float sensitivity = 5.0f; // Sensibilidad del mouse
    public Transform playerBody; // Objeto que representa al jugador (cuerpo)

    private float rotationX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear cursor
        Cursor.visible = false; // Ocultar cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -45.0f, 45.0f); // Limitar el ángulo vertical

        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f); // Rotación de la cámara en el eje X
        playerBody.Rotate(Vector3.up * mouseX); // Rotación del jugador en el eje Y
    }
}
