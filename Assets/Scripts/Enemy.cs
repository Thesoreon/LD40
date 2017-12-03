using UnityEngine;

public class Enemy : MonoBehaviour {

    private float MaxHealth = 100;
    public float Health;

    private float AttackSpeed = 1.5f;
    public float AS;

    public float Damage;

    public float Experiences;

    public GameObject number;

	void Start () {
        Health = MaxHealth;
        AS = AttackSpeed;
        Experiences = 10f;
        Damage = 10f;
	}

    private void Update()
    {
        if (AS > 0f)
            AS -= Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        Destroy(Instantiate(number, gameObject.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 1, 0), Quaternion.identity), 1.8f);
        
        Health -= amount;

        if (Health <= 0f)
            Die();
    }

    public void Attack(Transform target)
    {
        PlayerStats temp = target.GetComponent<PlayerStats>();
            
        temp.TakeDamage(Damage);

        AS = AttackSpeed;
    }

    private void Die()
    {
        Destroy(gameObject);

        PlayerStats temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        temp.AddXP(Experiences + temp.Kills);
    }
}
