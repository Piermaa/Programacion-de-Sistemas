using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
  [SerializeField] private TMP_Text playerHealthText;
  [SerializeField] private TMP_Text enemyHealthText;
  [SerializeField] private TMP_Text pickUpItemText;
    
  public static UIManager Instance;
  private Dictionary<string, Action<int>> actorActionOnUpdateHealth = new();
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
    InitializeDictionary();
  }

  public void UpdateActorHealth(string actorID, int healthLeft)
  {
    if (actorActionOnUpdateHealth.TryGetValue(actorID,out var onUpdateHealth))
    {
      onUpdateHealth.Invoke(healthLeft);
    }
  }

  private void InitializeDictionary()
  {
    actorActionOnUpdateHealth.Add("player",UpdatePlayerHealth);
    actorActionOnUpdateHealth.Add("enemy",UpdateEnemyHealth);
  }

  private void UpdatePlayerHealth(int playerHealth)
  {
    playerHealthText.text = playerHealth.ToString();
  }
    
  private void UpdateEnemyHealth(int enemyHealth)
  {
    playerHealthText.text = enemyHealth.ToString();
  }

  public void UpdatePickupItem(Item item)
  {
    bool isValidItem = item != null;
    pickUpItemText.text = $"item picked up {item.name}";
  }
}
