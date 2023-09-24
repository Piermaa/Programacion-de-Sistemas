using UnityEngine;
using UnityEngine.Serialization;

public class Actor : MonoBehaviour, IDamageable
{
  #region IDamageable Properties

  public int CurrentHealth => _currentHealth;
  public int MaxHealth => _stats.MaxLife;

  #endregion

  #region Serialized Variables

  [SerializeField] protected ActorStats _stats;
  [SerializeField] private ParticleSystem _bloodParticles;
  [SerializeField] private AudioSource _takingDamageSound;

  #endregion
    
  protected int _currentHealth;
    
  #region MonoBehaviour Callbacks


  protected virtual void Awake()
  {
    _currentHealth = MaxHealth;
  }
  #endregion

  #region IDamageable Methods

  public virtual void TakeDamage(int damage)
  {
    _takingDamageSound.Play();
    _bloodParticles.Play();
    _currentHealth -= damage;
    if (_currentHealth <= 0)
    {
      _currentHealth = 0;
      Death();
    }

    //print($"{name}'s current health: {_currentHealth}");
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
