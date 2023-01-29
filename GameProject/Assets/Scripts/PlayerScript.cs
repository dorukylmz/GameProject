using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHP = 100;
    public int maxMana = 50;
    public int maxGold = 1000;
    public int maxExp = 100;

    private int currentHP;
    private int currentMana;
    private int currentGold;
    private int currentExp;

    public Text HPText;
    public Text ManaText;
    public Text GoldText;
    public Text ExpText;
    private void Start()
    {
        currentHP = maxHP;
        currentMana = maxMana;
        currentGold = 0;
        currentExp = 0;

        UpdateUI();
    }

    private void UpdateUI()
    {
        HPText.text = "HP: " + currentHP + "/" + maxHP;
        ManaText.text = "Mana: " + currentMana + "/" + maxMana;
        GoldText.text = "Gold: " + currentGold;
        ExpText.text = "Exp: " + currentExp + "/" + maxExp;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateUI();
    }

    public void UseMana(int mana)
    {
        currentMana -= mana;
        UpdateUI();
    }

    public void EarnGold(int gold)
    {
        currentGold += gold;
        UpdateUI();
    }

    public void GainExp(int exp)
    {
        currentExp += exp;
        if (currentExp >= maxExp)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        currentExp -= maxExp;
        maxExp *= 2;
        // Add code here to unlock new skills or abilities.
    }
}
