using UnityEngine;

public class Enemy : MonoBehaviour {

    private float MaxHealth = 100;
    public float Health;

    private float AttackSpeed = 1.5f;
    public float AS;

	void Start () {
        Health = MaxHealth;
        AS = AttackSpeed;
	}

    private void Update()
    {
        if (AS > 0f)
            AS -= Time.deltaTime;
    }

    public void Attack(Transform target)
    {
        PlayerStats temp = target.GetComponent<PlayerStats>();

        temp.TakeDamage(10);

        AS = AttackSpeed;
    }
}
