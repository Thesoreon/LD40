using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    
    [Header("Stats")]
    private float MaxHealth = 100;
    public float Health;

    private float MaxXP = 100;
    public float currentXP;

    private float maxArmor = 0.9f;
    public float armor;

    public int Kills;
    public int Level;

    public int ImmortalPotion;
    public int HealPotion;

    [Header("Other")]
    public Image bar;
    public Image xpBar;
    public Text stats;

    public Text healCount;
    public Text immortalCount;

    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) Die();
    }

    private void Start()
    {
        Health = MaxHealth;
        currentXP = 0;
        Kills = 0;
        HealPotion = 0;
        ImmortalPotion = 1;
        Level = 1;
        armor = maxArmor;

        UpdateXpBar();
        UpdateCount();
    }

    public void TakeDamage(float amount)
    {
        Health -= (amount - amount * armor);
        UpdateBar();

        if (Health <= 0f)
            Die();
    }

    public void AddXP(float amount)
    {
        Kills++;
        DecreaseProtection();

        currentXP += amount;

        UpdateXpBar();

        if(currentXP >= MaxXP)
            LevelUp();
    }

    public void Heal(float amount)
    {
        if (HealPotion > 0)
        {
            HealPotion--;
            UpdateCount();

            if (Health + amount > 100)
                Health = 100;
            else
                Health += amount;

            UpdateBar();
        }
    }

    private void DecreaseProtection()
    {
        if (Kills <= 150)
            armor -= maxArmor * 0.006f;
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
            GameObject.Find("GameMaster").GetComponent<EnemySpawner>().SpawnTime -= 0.60f;

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
XP: {3}/{4}", Kills, System.Math.Round(armor, 2), Level, currentXP, System.Math.Round(MaxXP, 0));
    }

    public void UpdateCount()
    {
        healCount.text = HealPotion.ToString();
        immortalCount.text = ImmortalPotion.ToString();
    }

    public IEnumerator DrinkImmortal()
    {
        if (ImmortalPotion > 0)
        {
            ImmortalPotion--;
            UpdateCount();

            float temp = armor;

            armor = 1f;
            yield return new WaitForSeconds(2.5f);
            armor = temp;
        }
    }

    private IEnumerator AnimateLevel()
    {
        anim.SetBool("Swap", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Swap", false);
    }

    private void Die()
    {
        GameObject.Find("GameMaster").GetComponent<GameOver>().EndGame();

        Destroy(gameObject);
    }

}
