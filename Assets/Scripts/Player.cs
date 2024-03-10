using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del astronauta
    public float turnSmoothTime = 0.1f; // Suavizado de la rotación del astronauta
    public float gravity = 9.8f; // Gravedad aplicada al astronauta

    private CharacterController characterController;
    private float turnSmoothVelocity;
    private Vector3 velocity; // Variable para el control de la velocidad vertical

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveAstronaut();
    }

    private void MoveAstronaut()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        ApplyGravity();

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveVector = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveVector * speed * Time.deltaTime);
        }
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.5f; // Restablece la velocidad vertical cuando el astronauta está en el suelo
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
