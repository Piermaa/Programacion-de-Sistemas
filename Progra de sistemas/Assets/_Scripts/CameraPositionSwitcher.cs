using UnityEngine;
public class CameraPositionSwitcher : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("player");
            Main.transform.SetPositionAndRotation(cameraPosition.position,cameraPosition.rotation);
        }
    }
}
