using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField] GameObject camPosition;
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> wayPoints;

    bool isEnabled = false;

    // Update is called once per frame
    void Update()
    {
        float camLocation = transform.position.y - camPosition.transform.position.y;
   
        if (isEnabled == false && camLocation < 0.5) 
        {
            Quaternion rotation = new Quaternion(0f,0f,180f,0f);
            foreach(GameObject element in wayPoints)
            {
                Instantiate(enemy, element.transform.position, rotation);
            }

            isEnabled = true;
        }
    }

}
