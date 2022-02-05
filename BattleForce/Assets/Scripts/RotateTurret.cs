using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{
  //  [SerializeField] float rotationSpeed;
  //  [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] Vector3 angleToRoate = new Vector3(0f, 0f, 30f);

  //  float timeLeft = 1.0f;

    Vector3 angleToLeft = new Vector3(0, 0, -30f);

    float angleZ = 35.0f;

    bool isRight = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //angleZ += 2.0f;
        //RotateLeft();
        RotateByDegrees(angleZ);
        if(transform.rotation.eulerAngles.z >180 && transform.rotation.eulerAngles.z <90)
        {
            angleZ *= -1;
        }
     //   if(transform.rotation.eulerAngles.z )
     //   Debug.Log("Rotation : " + transform.rotation.eulerAngles.z);
        //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, 5.0f);

        // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    void RotateByDegrees(float angleZ)
    {
        Vector3 rotationToAdd = new Vector3(0f, 0f, angleZ)*Time.deltaTime;
        transform.Rotate(rotationToAdd);
    }
    void RotateLeft()
    {
        Vector3 newRotation = new Vector3(0, 0, angleZ*Time.deltaTime);
        transform.eulerAngles = newRotation;


        //  this.transform.Rotate(0f, 0f, 10f * Time.deltaTime);
        //   Debug.Log("Rotation : " + this.transform.localRotation.z * Mathf.PI);
        //if (transform.rotation.z >= 180 && transform.rotation.z <= 360)
        //  {
        //      this.transform.Rotate(0f, 0f, 10f * Time.deltaTime);
        //      isRight = false;
        //   }
    }

    void RotateRight()
    {

            this.transform.Rotate(0f, 0f, -10f * Time.deltaTime);
        //    Debug.Log("Rotation : " + transform.rotation.z);
        //if (transform.rotation.z >= 0 && transform.rotation.z <= 180)
        //{
        //    this.transform.Rotate(0f, 0f, -10f * Time.deltaTime);
        //    isRight = true;
        //}
    }
}
