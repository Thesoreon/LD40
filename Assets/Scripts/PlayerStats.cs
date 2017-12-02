using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    
    private float MaxHealth = 100;
    public float Health;

    private float MaxXP = 100;
    public float currentXP;

    public Image bar;
    public Image xpBar;

    private void Start()
    {
        Health = MaxHealth;
        currentXP = 0;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        UpdateBar();

        if (Health <= 0f)
            Die();
    }

    public void AddXP(float amount)
    {
        currentXP += amount;

        UpdateXpBar();
    }

    private void UpdateBar()
    {
        bar.fillAmount = Health / MaxHealth;
    }

    private void UpdateXpBar()
    {
        xpBar.fillAmount = currentXP / MaxXP;
    }

    private void Die()
    {
        Debug.Log("You died");
    }

}
