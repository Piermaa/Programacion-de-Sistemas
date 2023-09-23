using UnityEngine;
public class CameraPositionSwitcher : OnPlayerTriggerEnter
{
    [SerializeField] private Transform cameraPosition;
    public static Camera Main;

    private void Awake()
    {
        if (Main==null)
        {
            Main=Camera.main;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cameraPosition.position,cameraPosition.forward*10);
    }

    public override void OnPlayerCharacterTriggerEnter()
    {
        Main.transform.SetPositionAndRotation(cameraPosition.position,cameraPosition.rotation);
    }
}
