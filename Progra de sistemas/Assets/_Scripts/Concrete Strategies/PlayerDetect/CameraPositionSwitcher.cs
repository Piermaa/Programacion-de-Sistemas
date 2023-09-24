using UnityEngine;
using UnityEngine.Serialization;

public class CameraPositionSwitcher : OnPlayerTriggerEnter
{
    [FormerlySerializedAs("cameraPosition")] [SerializeField] private Transform _cameraPosition;
    [FormerlySerializedAs("Main")] [SerializeField] private Camera cam;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_cameraPosition.position,_cameraPosition.forward*10);
    }

    public override void OnPlayerCharacterTriggerEnter()
    {
        cam.transform.SetPositionAndRotation(_cameraPosition.position,_cameraPosition.rotation);
    }
}
