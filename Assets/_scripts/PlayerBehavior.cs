using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public CharacterController controller;

    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    public GameObject overworldSpawn;
    public GameObject underworldSpawn;

    public Camera playerCamera;
    public LayerMask interactableMask;
    public GameObject interactUI;

    private Interactable interactableObject;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OverworldBed")
        {
            Debug.Log("Found overworldBed");
            controller.enabled = false;
            transform.position = new Vector3(underworldSpawn.transform.position.x, underworldSpawn.transform.position.y, underworldSpawn.transform.position.z);
            controller.enabled = true;
        }
        else if (other.gameObject.name == "UnderworldBed")
        {
            controller.enabled = false;
            transform.position = new Vector3(overworldSpawn.transform.position.x, overworldSpawn.transform.position.y, overworldSpawn.transform.position.z);
            controller.enabled = true;
        }
    }
}
