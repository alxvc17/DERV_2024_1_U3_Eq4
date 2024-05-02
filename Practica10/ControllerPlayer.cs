using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public CharacterController controller;
    public float caminar = 6f;
    public float correr = 12f;
    public float gravedad = -9.81f;
    public float Salto = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 Caminar;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Caminar.y < 0)
        {
            Caminar.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * caminar * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Caminar.y = Mathf.Sqrt(Salto * -3f * gravedad);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * correr * Time.deltaTime);
        }

        Caminar.y += gravedad * Time.deltaTime;

        controller.Move(Caminar * Time.deltaTime);
    }

}
