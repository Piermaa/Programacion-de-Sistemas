using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class WeaponsUIManager
{
    #region Serialized Variables

    [SerializeField] private TMP_Text bulletsText;
    [SerializeField] private Image currentWeapon;
    [SerializeField] private Sprite[] weapons;

    #endregion

    #region Class Methods

    public void UpdateBullets(int remainingAttacks, int maxBullets)
    {
        bulletsText.text = $"{remainingAttacks}/{maxBullets}";
    }

    public void EquippedWeapon(int index)
    {
        currentWeapon.sprite = weapons[index];
        currentWeapon.SetNativeSize();
    }

    #endregion
}