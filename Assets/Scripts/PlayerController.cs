using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerMovement movement;

	void Start () {
        movement = GetComponent<PlayerMovement>();
	}
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.A))
            movement.Move(-150);
        else if (Input.GetKey(KeyCode.D))
            movement.Move(150);

        if (Input.GetKey(KeyCode.Space))
            movement.Jump(150);
	}
}
