using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform[] Borders;

    private bool grounded;
    private float min, max;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        max = Borders[0].position.x;
        min = Borders[1].position.x;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), transform.position.y,  transform.position.z);
    }

    public void Move(float speed)
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    public void Jump(float force)
    {
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, force * Time.deltaTime);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            grounded = true;
    }
    
}
