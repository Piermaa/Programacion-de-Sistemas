using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerUIManager
{
    [SerializeField] private Image playerHealthBar;

    public void UpdatePlayerHealth(int playerCurrentHealth, int playerMaxHealth)
    {
        playerHealthBar.fillAmount = (float)playerCurrentHealth / playerMaxHealth;
    }
}