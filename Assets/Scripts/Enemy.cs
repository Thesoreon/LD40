using UnityEngine;

public class Enemy : MonoBehaviour {

    private float MaxHealth = 100;
    public float Health;

    private float AttackSpeed = 1.5f;
    public float AS;

    public GameObject number;

	void Start () {
        Health = MaxHealth;
        AS = AttackSpeed;
	}

    private void Update()
    {
        if (AS > 0f)
            AS -= Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        Destroy(Instantiate(number, gameObject.transform.position, Quaternion.identity), 1.8f);
        
        Health -= amount;

        if (Health <= 0f)
            Die();
    }

    public void Attack(Transform target)
    {
        PlayerStats temp = target.GetComponent<PlayerStats>();

        temp.TakeDamage(10);

        AS = AttackSpeed;
    }

    private void Die()
    {
        Destroy(gameObject);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().AddXP(5f);
    }
}
