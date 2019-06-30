using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public GameManagement manager;
    public float moveSpeed;
    public bool jumpAvailability;
    public static bool canMove = true;
    public GameObject deathParticles;

    private float maxSpeed = 5f;
    private bool isGrounded;
    private Vector3 input;
    private Vector3 spawn;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawn = transform.position;
    }


    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (canMove && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(input * moveSpeed);
        }
        
        if (Input.GetKeyDown("space") && isGrounded && jumpAvailability)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 10, ForceMode.Impulse);
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
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Wall")
        {
            if (collision.contacts.Length > 0)
            {
                ContactPoint contact = collision.contacts[0];
                if (Vector3.Dot(contact.normal, Vector3.up) > 0)
                {
                    isGrounded = true;
                }
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Wall")
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
