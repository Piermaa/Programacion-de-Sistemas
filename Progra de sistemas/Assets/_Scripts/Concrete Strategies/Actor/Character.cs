using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : Actor
{
    #region Serialized Variables

    [SerializeField] private List<MovementController> _movementControllers=new();
    [SerializeField] private List<GameObject> _weaponList = new();
    #endregion

    #region Class Properties

    private IWeapon _currentWeapon;
    private IMovable _movable;

    #endregion
    
    #region Commands

    
    private CmdMove _cmdMoveForward;
    private CmdMove _cmdMoveBack;

    private CmdTurn _cmdTurnRight;
    private CmdTurn _cmdTurnLeft;
    
    private CmdAttack _cmdAttack;
    private CmdReload _cmdReload;

    #endregion

    #region Key Bindings

    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _aim = KeyCode.Mouse1;
    [SerializeField] private KeyCode _reload = KeyCode.R;

    [SerializeField] private KeyCode _weaponSlot1= KeyCode.Alpha1;
    [SerializeField] private KeyCode _weaponSlot2= KeyCode.Alpha2;
    [SerializeField] private KeyCode _weaponSlot3= KeyCode.Alpha3;

    [SerializeField] private KeyCode _run = KeyCode.LeftShift;
    [SerializeField] private Animator _animator;
    #endregion

    #region Monobehaviour Callbacks

    private void Start()
    {
        SwitchMovement(0);
        SwitchWeapon(0);
    }

    private void Update()
    {
        //ARMAS
        //podrian ser comandos
        if (!_animator.GetBool(("isWalking")))
        {
            if (Input.GetKeyDown(_aim)) Aiming();
            
            if (Input.GetKeyDown(_attack)) GameManager.instance.AddEvents(_cmdAttack);
            if (Input.GetKeyDown(_reload)) GameManager.instance.AddEvents(_cmdReload);
        }
        
        if (Input.GetKeyUp(_aim)) StopAiming();
        
        if (Input.GetKeyDown(_weaponSlot1)) SwitchWeapon(0);
        if (Input.GetKeyDown(_weaponSlot2)) SwitchWeapon(1);
        if (Input.GetKeyDown(_weaponSlot3)) SwitchWeapon(2);

        //=======================debug========================
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(1);
        //Movement
        if (!_animator.GetBool(("isAiming")))
        {
            if (Input.GetKeyDown(_run)) SwitchMovement(1);
            if (Input.GetKeyUp(_run)) SwitchMovement(0);
        
            if (Input.GetKey(_moveForward))  GameManager.instance.AddEvents(_cmdMoveForward);   
            if (Input.GetKey(_moveBack)) GameManager.instance.AddEvents(_cmdMoveBack);
        }
        
        if (Input.GetKey(_moveLeft)) GameManager.instance.AddEvents(_cmdTurnLeft); 
        if (Input.GetKey(_moveRight))  GameManager.instance.AddEvents(_cmdTurnRight);
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") == 0) _movable.StopMove();
    }

    #endregion

    #region Class Methods

    #region Switch Strategies

    private void SwitchMovement(int index)
    {
        _movable = _movementControllers[index];
        _cmdTurnLeft = new CmdTurn(_movable,-1);
        _cmdTurnRight = new CmdTurn(_movable,1);
        
        _cmdMoveBack = new CmdMove(_movable,-1);
        _cmdMoveForward = new CmdMove(_movable, 1);
    }

    private void SwitchWeapon(int index)
    {
        foreach (var weapon in _weaponList)
        {
            weapon.gameObject.SetActive(false);
        }

        _weaponList[index].gameObject.SetActive(true);
        _currentWeapon = _weaponList[index].GetComponent<IWeapon>();
        
        _cmdAttack = new CmdAttack(_currentWeapon);
        _cmdReload = new CmdReload(_currentWeapon);
        _cmdReload.Do();
        _currentWeapon.UpdateUI();
        UIManager.Instance.WeaponsUI.EquippedWeapon(index);
    }

    #endregion

    private void Aiming()
    {
        _currentWeapon.Aim();
        _animator.SetBool("isAiming",true);
    }

    private void StopAiming()
    {
        _currentWeapon.StopAiming();
        _animator.SetBool("isAiming",false);
    }
 
    #endregion

    #region Actor Overrided Methods

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UIManager.Instance.PlayerUI.UpdatePlayerHealth(CurrentHealth,_stats.MaxLife);
    }

    public override void Death()
    {
        GetComponent<IOnDeath>().Death();
    }

    #endregion

    #region Public Class Methods

    public void Heal(int damage)
    {
        _currentHealth+=damage;
        if (CurrentHealth>MaxHealth)
        {
            _currentHealth = MaxHealth;
        }

        UIManager.Instance.PlayerUI.UpdatePlayerHealth(CurrentHealth,_stats.MaxLife);
    }

    public void PickUpBullets(int index, int bulletsToAdd)
    {
        if (index>0)
        {
            _weaponList[index].GetComponent<ReloadableWeapon>().BulletsInStock+=bulletsToAdd;
            _currentWeapon.UpdateUI();
        }
    }

    #endregion
    
}
