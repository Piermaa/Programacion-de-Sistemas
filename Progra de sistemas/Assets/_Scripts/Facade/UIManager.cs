using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  public static UIManager Instance;

  public PlayerUIManager PlayerUI => _playerUIManager;
  public WeaponsUIManager WeaponsUI => _weaponsUIManager;
  
  [SerializeField] private TMP_Text enemyHealthText;
  [SerializeField] private TMP_Text pickUpItemText;
  [SerializeField] private PlayerUIManager _playerUIManager;
  [SerializeField] private WeaponsUIManager _weaponsUIManager;
  private void Awake()
  {
    if (Instance!=null)
    {
      Destroy(this);
      return;
    }
    else
    {
      Instance = this;
    }
  }

  // public void UpdateActorHealth(string actorID, int healthLeft)
  // {
  //   if (actorActionOnUpdateHealth.TryGetValue(actorID,out var onUpdateHealth))
  //   {
  //     onUpdateHealth.Invoke(healthLeft);
  //   }
  // }
}

[Serializable]
public class PlayerUIManager
{
  [SerializeField] private Image playerHealthBar;

  public void UpdatePlayerHealth(int playerCurrentHealth, int playerMaxHealth)
  {
    playerHealthBar.fillAmount = (float)playerCurrentHealth / playerMaxHealth;
  }
}
[Serializable]
public class WeaponsUIManager
{
  [SerializeField] private TMP_Text bulletsText;
  [SerializeField] private Image currentWeapon;
  [SerializeField] private Sprite[] weapons;
  public void UpdateBullets(int remainingAttacks, int maxBullets)
  {
    
    bulletsText.text = $"{remainingAttacks}/{maxBullets}";
  }

  public void EquippedWeapon(int index)
  {
    currentWeapon.sprite = weapons[index];
  }
}