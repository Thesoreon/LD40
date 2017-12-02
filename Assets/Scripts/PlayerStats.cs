using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    
    [Header("Stats")]
    private float MaxHealth = 100;
    public float Health;

    private float MaxXP = 100;
    public float currentXP;

    public float armor;
    public int Kills;
    public int Level;

    [Header("Other")]
    public Image bar;
    public Image xpBar;
    public Text stats;

    public Animator anim;

    private void Start()
    {
        Health = MaxHealth;
        currentXP = 0;
        Kills = 0;
        Level = 1;
        armor = 0.25f;

        UpdateXpBar();
    }

    public void TakeDamage(float amount)
    {
        Health -= amount * armor;
        UpdateBar();

        if (Health <= 0f)
            Die();
    }

    public void AddXP(float amount)
    {
        DecreaseProtection();
        Kills++;

        currentXP += amount;

        UpdateXpBar();

        if(currentXP >= MaxXP)
            LevelUp();
    }

    private void DecreaseProtection()
    {
        if (Kills <= 100)
            armor -= armor * 0.01f;
        else
            armor = 0f;
    }

    private void LevelUp()
    {
        MaxXP += 0.3f * MaxXP;

        currentXP = 0;
        Level++;

        UpdateXpBar();

        if(Level <= 5)
            GameObject.Find("GameMaster").GetComponent<EnemySpawner>().SpawnTime -= 0.5f;

        StartCoroutine(AnimateLevel());
    }

    private void UpdateBar()
    {
        bar.fillAmount = Health / MaxHealth;
    }

    private void UpdateXpBar()
    {
        xpBar.fillAmount = currentXP / MaxXP;

        stats.text = string.Format(@"Level: {2}
Kills: {0}
Armor: {1}
XP: {3}/{4}", Kills, System.Math.Round(armor, 2), Level, currentXP, MaxXP);
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
