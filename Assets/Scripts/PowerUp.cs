using UnityEngine;

public class PowerUp : MonoBehaviour {

    public bool Immortal = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerStats temp = collision.gameObject.GetComponent<PlayerStats>();

            if (!Immortal)
                temp.HealPotion++;
            else
                temp.ImmortalPotion++;

            temp.UpdateCount();

            Destroy(gameObject);
        }
    }

}
