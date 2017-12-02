using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private bool grounded;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
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
