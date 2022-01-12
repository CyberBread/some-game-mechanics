using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float minFall = -1.5f;

    private float vertSpeed;
    private Vector3 movement;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;

        movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement = transform.TransformDirection(movement);

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                vertSpeed = jumpSpeed;
            else
                vertSpeed = minFall;

        }
        else
            vertSpeed += gravity * Time.deltaTime;

        movement.y = vertSpeed;
        movement *= Time.deltaTime;
        characterController.Move(movement);
    }
}
