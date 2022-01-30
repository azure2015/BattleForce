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

    // Start is called before the first frame update
    void Start()
    {
        //   moveDown();
      //  RotateLeft();
        this.transform.Rotate(angleToRoate); // * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        RotateLeft();
        //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, 5.0f);

        // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    void RotateLeft()
    {
        Debug.Log("Rotation : " + transform.rotation.z);
        this.transform.Rotate(0f,0f,10f * Time.deltaTime);
    }
}
