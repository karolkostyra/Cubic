using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public GameManagement manager;
    public float rotationRate = 180;
    public float moveSpeed = .1f;
    public bool jumpAvailability;
    public GameObject deathParticles;

    private bool isGrounded;
    private Vector3 input;
    private Vector3 spawn;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawn = transform.position;
    }


    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        Move(moveAxis);
        Turn(turnAxis);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpAvailability)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 10, ForceMode.Impulse);
        }


        if (transform.position.y < -2)
        {
            Die();
            transform.rotation = Quaternion.identity; //to reset rotation
        }
    }


    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
    }


    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
            Die();
    }

    
    private void OnCollisionStay(Collision collision)
    {
        //if (collision.transform.tag == "Ground")
        //isGrounded = true;
        if (collision.transform.tag == "Ground")
        {
            if (collision.contacts.Length > 0)
            {
                ContactPoint contact = collision.contacts[0];
                if (Vector3.Dot(contact.normal, Vector3.up) > 0)
                {
                    isGrounded = true;
                    //collision was from below
                }
                //else
                //isGrounded = false;
            }
        }
    }
    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            isGrounded = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
            Die();

        if (other.transform.tag == "Goal")
        {
            manager = manager.GetComponent<GameManagement>();
            manager.CompleteLevel();
        }
    }


    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
