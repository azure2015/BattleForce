using UnityEngine;

/**
 *  Follow camera:
 *  
 *  Edited from video tutorial
 *  
 *  Using two vector points for bottom left and top right the camera is locked within the area
 *  Using the target, being the player and smoothing to catch up the camera to the player.
 */
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing;

    [SerializeField] Vector2 maxPos;
    [SerializeField] Vector2 minPos;

    float cameraOffsetY = 2.0f;

    void FixedUpdate()
    {
        // Only check if we move camera if the player is at the end of offset
        if (transform.position.y  > target.position.y + cameraOffsetY || transform.position.y < target.position.y - cameraOffsetY)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, 0);
            }
        }

        if (transform.position.x != target.position.x)
        {
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
