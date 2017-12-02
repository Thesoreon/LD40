using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject GFX;

    private PlayerMovement movement;

    public Animator anim;

	void Start () {
        movement = GetComponent<PlayerMovement>();
	}
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.A))
        {
            GFX.transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, 0f);
            movement.Move(-150);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GFX.transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z, 0f);
            movement.Move(150);
        }

        if(Input.GetKeyDown(KeyCode.E))
            anim.SetBool("Show", !anim.GetBool("Show"));

        if (Input.GetKey(KeyCode.Space))
        {
           movement.Jump(300);
        }
	}
}
