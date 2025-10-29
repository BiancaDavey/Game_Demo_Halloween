using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private float smooth = 1;
    public Vector2 maxXY;
    public Vector2 minXY;

    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            //  Set target position.
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            //  Set xy coordinates for camera boundary for scene.
            targetPosition.x = Mathf.Clamp(targetPosition.x, minXY.x, maxXY.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minXY.y, maxXY.y);
            //  Move camera position to target position.
            transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
        }
    }
}
