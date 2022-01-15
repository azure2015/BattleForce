using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] float moveCamSpeed = 5;


    float minXPos = -1.2f; // -3.2f;
   // float maxXPos = 2.2f;

    [SerializeField] CinemachineVirtualCamera cineCam;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cineCam.transform.localPosition.x < minXPos)
        {
            var pos = new Vector2(minXPos, transform.position.y);
            transform.position = pos;

        }
        // transform.Translate(new Vector3(0.0f, moveCamSpeed * Time.deltaTime, 0.0f));
        Debug.Log("Cam : " + cineCam.transform.localPosition.x); 
    //   cineCam.
    }
}
