using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] float moveCamSpeed = 5;

    CinemachineVirtualCamera cineCam;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.0f, moveCamSpeed * Time.deltaTime, 0.0f));
    }
}
