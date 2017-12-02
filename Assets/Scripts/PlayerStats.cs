using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    
    private float MaxHealth = 100;
    public float Health;

    private float MaxXP = 100;
    public float currentXP;

    public Image bar;
    public Image xpBar;

    public Animator anim;

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

        if(currentXP >= MaxXP)
            LevelUp();
    }

    private void UpdateBar()
    {
        bar.fillAmount = Health / MaxHealth;
    }

    private void UpdateXpBar()
    {
        xpBar.fillAmount = currentXP / MaxXP;
    }

    private void LevelUp()
    {
        MaxXP += 0.3f * MaxXP;

        currentXP = 0;
        UpdateXpBar();

        GameObject.Find("GameMaster").GetComponent<EnemySpawner>().SpawnTime -= 0.5f;

        StartCoroutine(AnimateLevel());
    }

    private IEnumerator AnimateLevel()
    {
        anim.SetBool("Swap", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Swap", false);
    }

    private void Die()
    {
        Debug.Log("You died");
    }

}
