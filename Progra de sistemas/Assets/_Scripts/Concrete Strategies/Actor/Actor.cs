using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{
  #region Public vars

  public int CurrentHealth => _currentHealth;
  public int MaxHealth => _stats.MaxLife;

  #endregion

  [SerializeField] protected ActorStats _stats;
  [SerializeField] private ParticleSystem _bloodParticles;
  private int _currentHealth;

  private CmdDie _cmdDie;
  
  #region MonoBehaviour Callbacks


  protected virtual void Awake()
  {
    _currentHealth = MaxHealth;
  }
  #endregion

  #region IDamageable Implementation

  public virtual void TakeDamage(int damage)
  {
    _bloodParticles.Play();
    _currentHealth -= damage;
    if (_currentHealth <= 0)
    {
      _currentHealth = 0;
      Death();
    }

    print($"{name}'s current health: {_currentHealth}");
  }
  public virtual void Death()
  {
    gameObject.SetActive(false);
  }

  public void Revive()
  {
    _currentHealth = (int)(_stats.MaxLife * .15f);
    gameObject.SetActive(true);
  }

  #endregion
}
