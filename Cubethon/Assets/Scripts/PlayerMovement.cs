using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;
    private BoxCollider _col;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpVelocity = 1f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private bool doJump = false;

    void Start()
    {
        _col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(Input.GetKey("w"))
        {
            doJump = true;
        }
    }

    // We marked this as "FixedUpdate" becasue we are using it to mess with physics

    void FixedUpdate()
    {
        if (doJump)
        {
            rb.AddForce(Vector3.up / jumpVelocity, ForceMode.Impulse);
            doJump = false;
        }
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Add a forward force on the z-axis

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
