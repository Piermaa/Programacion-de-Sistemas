using UnityEngine;

public class MovementController : MonoBehaviour, IMovable
{
    //clase que implemente el como se lleva a cabo la estrategia

    #region IMovable Properties

    public float MovementSpeed => _movementSpeed;


    #endregion

    #region Serialized Variables

    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator _animator;

    #endregion

    #region Class Properties

    private Vector3 _meshLocalPos = new Vector3(0, -1, 0);
    private Quaternion _meshLocalRot=Quaternion.Euler(new Vector3(0, 0, 0));

    #endregion

    #region Monobehaviour Callbacks

    private void LateUpdate()
    {
        if (!_animator.GetBool("isWalking"))
        {
            _animator.transform.localPosition = _meshLocalPos;
            _animator.transform.localRotation = _meshLocalRot;
        }
    }


    #endregion

    #region IMovable Methods

    public virtual void Move(float direction)
    {
        _animator.SetBool("isWalking",true);
        transform.position += direction * Time.deltaTime * _movementSpeed* transform.forward;
    }

    public virtual void Turn(float direction)
    {
        transform.Rotate(direction*Time.deltaTime*_turnSpeed*Vector3.up);
    }
    
    #endregion

    #region Class Methods

    public void StopMove()
    {
        _animator.SetBool("isWalking", false);
    }

    #endregion
}
