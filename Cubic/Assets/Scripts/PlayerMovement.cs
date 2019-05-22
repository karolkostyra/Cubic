using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public bool jumpAvailability = true;
    public GameObject deathParticles;
    
    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;

    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawn = transform.position;
    }


    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(input * moveSpeed);
        }

        if (Input.GetKeyDown("space") & isGrounded & jumpAvailability)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 10, ForceMode.Impulse);
            isGrounded = false;
            
        }

        if (transform.position.y < -2)
        {
            Die();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Die();
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }


    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }

        if (other.transform.tag == "Goal")
        {
            GameManagement.CompleteLevel();
        }
    }


    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
