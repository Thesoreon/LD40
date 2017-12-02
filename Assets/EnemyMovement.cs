using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Transform target;

    private float distance;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate () {

        distance = Vector3.Distance(target.position, transform.position);

        if (distance > 1.4f)
            transform.Translate(1 * Time.deltaTime, 0, 0);
        else
            Debug.Log("Attacking");


        if (transform.position.x > target.position.x)
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        else
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
    }
}
