using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float g = -9.81f;
    public float jumpHeight = 1f;

    public Transform player;
    public LayerMask groundMask;
    public LayerMask headMask;

    private Vector3 gravity;
    private bool isGrounded;
    private bool canJump;
    private Vector3 sphereCenter;
    private float sphereRadius;
    private float sphereOffset;
    Vector3 normalizedVector;
    float x;
    float z;
    float a;
    float l;
    Vector3 acc;

    private void Start()
    {
        sphereRadius = controller.radius;
        sphereOffset = controller.height / 2 - sphereRadius + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        sphereCenter = player.transform.localPosition;
        sphereCenter.y -= sphereOffset;
        canJump = Physics.CheckSphere(sphereCenter, sphereRadius, groundMask);
        isGrounded = canJump || Physics.CheckSphere(sphereCenter, sphereRadius, headMask);

        acc = Input.acceleration;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        normalizedVector = NormalizeVector(x, z);
        Vector3 move = transform.right * normalizedVector.x + transform.forward * normalizedVector.z;
        move *= speed;

        if (isGrounded)
        {
            gravity.y = -0.1f;
        }

        if (isGrounded && canJump && Input.GetButtonDown("Jump"))
        {
            gravity.y = Mathf.Sqrt(jumpHeight * -2 * g);
        }
        else if (!isGrounded)
        {
            gravity.y += g * time;
        }

        controller.Move(move * time);
        controller.Move(gravity * time);
    }

    public Vector3 NormalizeVector(float x, float z)
    {
        if (Mathf.Abs(x) > Mathf.Abs(z) && x != 0)
        {
            a = z / x; //  z = -1; x = 0.1;  

        }
        else if (Mathf.Abs(x) < Mathf.Abs(z) && z != 0)
        {
            a = x / z;
        }
        else
        {
            a = 1f;
        }

        l = Mathf.Sqrt(1f + Mathf.Pow(a, 2f));
        x /= l;
        z /= l;

        return new Vector3(x, 0f, z);
    }
}
