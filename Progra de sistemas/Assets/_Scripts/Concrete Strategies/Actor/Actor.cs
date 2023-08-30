using UnityEngine;

public class Actor : MonoBehaviour , IDamageable
{
  #region Public vars
  public int CurrentHealth => _currentHealth;
  public int MaxHealth => _stats.MaxLife;
  #endregion

  private int _currentHealth;
  [SerializeField] protected ActorStats _stats;
    
  #region MonoBehaviour Callbacks

  private void Awake()
  {
    _currentHealth = MaxHealth;
  }

  #endregion
  #region IDamageable Implementation

  public virtual void TakeDamage(int damage)
  {
    _currentHealth -= damage;
    if (_currentHealth<=0)
    {
      _currentHealth = 0;
      Death();
    }
    print($"{name}'s current health: {_currentHealth}");
  }

  public void Death()
  {
      
  }
  #endregion
}
