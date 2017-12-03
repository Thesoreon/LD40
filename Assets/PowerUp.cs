using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float amount;

    private void Start()
    {
        amount = 10f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().Heal(amount);

            Destroy(gameObject);
        }
    }

}
