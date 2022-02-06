using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 35.0f;
    [SerializeField] Vector3 angleToRoate = new Vector3(0f, 0f, 30f);

    Vector3 angleToLeft = new Vector3(0, 0, -30f);

    float currentAngle = 0;

    bool turrentEnd = false;
    bool moveBack = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        int count = FindObjectsOfType<GunPost>().Length;
        currentAngle = transform.rotation.eulerAngles.z;
        
        if (count > 0 && !turrentEnd)
        {
             RotateByDegrees(rotationSpeed);
        } else if (!turrentEnd && (currentAngle >185 || currentAngle <175))
        {
            RotateByDegrees(rotationSpeed);
        } else
        {
            Debug.Log("True");
            turrentEnd = true;
        }

        if(turrentEnd)
        {
            RotateByDegrees(rotationSpeed);
            if (currentAngle > 220 && !moveBack)
            {
                Debug.Log("Angle : " + currentAngle);
                rotationSpeed = rotationSpeed * -1;
                moveBack = true;
            }
            if( currentAngle <150 && moveBack)
            {
                rotationSpeed *= -1;
                moveBack = false;
            }

        }

    }

    void RotateByDegrees(float angleZ)
    {
        Vector3 rotationToAdd = new Vector3(0f, 0f, angleZ)*Time.deltaTime;
        transform.Rotate(rotationToAdd);
    }
}
