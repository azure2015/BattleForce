using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float smoothing;

    [SerializeField] Vector2 maxPos;
    [SerializeField] Vector2 minPos;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log($"CAM [{target.name}]  :" + target.position.y);

        //if(target.position.y > 5.0f)
        //{
        //    Debug.Log("High"); 
        //}

        //if (target.position.y < 1.0f)
        //{
        //    Debug.Log("Low");
        //}
     //   )
        if (transform.position.y  > target.position.y + 2.0f || transform.position.y < target.position.y - 2.0f)
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
         //   targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

        }

    }


}
