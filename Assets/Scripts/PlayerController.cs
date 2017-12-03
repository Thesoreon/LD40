using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject GFX;

    private PlayerMovement movement;

    public Animator[] anim;

	void Start () {
        movement = GetComponent<PlayerMovement>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A))
        {
            GFX.transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, 0f);
            movement.Move(-150);

            anim[1].SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GFX.transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z, 0f);
            movement.Move(150);

            anim[1].SetBool("Run", true);
        }
        else anim[1].SetBool("Run", false);
       

        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(animateJump());
            movement.Jump(300);
        }
	}

    private IEnumerator animateJump()
    {
        anim[1].SetBool("Jump", true);
        yield return new WaitForSeconds(1f);
        anim[1].SetBool("Jump", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) GetComponent<PlayerStats>().Heal(40f);
        if (Input.GetKeyDown(KeyCode.S)) StartCoroutine(GetComponent<PlayerStats>().DrinkImmortal());
        if (Input.GetKeyDown(KeyCode.E)) anim[0].SetBool("Show", !anim[0].GetBool("Show"));
    }
}
