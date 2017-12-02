using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    
    private float MaxHealth = 100;
    public float Health;

    public Image bar;

    private void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        UpdateBar();

        if (Health <= 0f)
            Die();
    }

    private void UpdateBar()
    {
        bar.fillAmount = Health / MaxHealth;
    }

    private void Die()
    {
        Debug.Log("You died");
    }

}
