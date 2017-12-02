using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private Transform target;

    private float distance;

    private Enemy enemy;

    public Animator anim;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Enemy>();

        anim.SetBool("Attack", true);
	}
	
	void FixedUpdate () {

        distance = Vector3.Distance(target.position, transform.position);

        if (distance > 1.4f)
            transform.Translate(1 * Time.deltaTime, 0, 0);
        else
            enemy.Attack(target);

        if (transform.position.x > target.position.x)
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        else
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
    }
}
