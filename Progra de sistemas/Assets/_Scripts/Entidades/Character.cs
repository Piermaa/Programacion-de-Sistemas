using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : Actor
{
    [SerializeField] private List<MovementController> _movementControllers=new();
    [SerializeField] private List<GameObject> _weaponList = new();
    
    //TIENE QUE SET UN GETTER PORQUE NO SE PUEDE ACCEDER EN TIEMPO DE COMPILACION AL VALOR DEL SCRIPTABLE OJETE
    private float _movementSpeed => _stats.MovementSpeed;
    private IWeapon _currentWeapon;
    private IMovable _movable;

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
    #endregion
    //clase que consume la estrategia
    //se pueden cambiar los movementcontroller entre varios, por ejemplo, uno para correr otro para caminar etc
    //como al switchear armas, se switchean tipos movimientos
    //formas distintas de implementar lo mismo
    //mas maleable y optimizado

    private void Start()
    {
        SwitchMovement(0);
        SwitchWeapon(0);
        _currentWeapon.Reload();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_attack)) _currentWeapon.Attack();
        if (Input.GetKeyDown(_reload)) _currentWeapon.Reload();
        
        if (Input.GetKeyDown(_aim)) _currentWeapon.Aim();
        if (Input.GetKeyUp(_aim)) _currentWeapon.StopAiming();

        if (Input.GetKeyDown(_weaponSlot1)) SwitchWeapon(0);
        if (Input.GetKeyDown(_weaponSlot2)) SwitchWeapon(1);
        if (Input.GetKeyDown(_weaponSlot3)) SwitchWeapon(2);

        if (Input.GetKeyDown(_run)) SwitchMovement(1);
        if (Input.GetKeyUp(_run)) SwitchMovement(0);


        if (Input.GetKey(_moveForward)) _movable.Move(transform.forward);
        if (Input.GetKey(_moveBack)) _movable.Move(transform.forward*-1);
        if (Input.GetKey(_moveLeft)) _movable.Turn(-1);
        if (Input.GetKey(_moveRight)) _movable.Turn(1);
    }

    private void SwitchMovement(int index)
    {
        _movable = _movementControllers[index];
    }

    private void SwitchWeapon(int index)
    {
        foreach (var weapon in _weaponList)
        {
            weapon.gameObject.SetActive(false);
        }

        _weaponList[index].gameObject.SetActive(true);
        _currentWeapon = _weaponList[index].GetComponent<IWeapon>();
        _currentWeapon.Reload();
    }
}
