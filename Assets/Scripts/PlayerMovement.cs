using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform player;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 playerBottom;
    private Vector3 boxSize;

    private void Start()
    {
        boxSize = new Vector3(controller.radius, groundDistance, controller.radius);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float time = Time.deltaTime;
        playerBottom = player.transform.localPosition;
        playerBottom.y -= controller.height / 2;
        Quaternion q = new Quaternion(0f, 0f, 0f, 0f);
        isGrounded = Physics.CheckBox(playerBottom, boxSize, q, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        move *= speed * time;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.1f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity) * time;
        }
        else
        {
            velocity.y += gravity * time * time;
        }

        controller.Move(move);
        controller.Move(velocity);
    }
}
