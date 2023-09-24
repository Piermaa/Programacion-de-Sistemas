using UnityEngine;

public class UIManager : MonoBehaviour
{
  #region Facade

  public PlayerUIManager PlayerUI => _playerUIManager;
  public WeaponsUIManager WeaponsUI => _weaponsUIManager;

  [SerializeField] private PlayerUIManager _playerUIManager;
  [SerializeField] private WeaponsUIManager _weaponsUIManager;
  #endregion

  #region Singleton

  public static UIManager Instance;

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
  
  #endregion
}


