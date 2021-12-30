using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField] GameObject playerPosition;
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> wayPoints;
  //  [SerializeField] GameObject wayPoint;

    Vector2 startPosition;

    bool isEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
   //     startPosition = wayPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition.transform.position);
        if (isEnabled == false && distance < 2)
        {
            Quaternion rotation = new Quaternion();
            rotation[2] = 180f;
            foreach(GameObject element in wayPoints)
            {
                Instantiate(enemy, element.transform.position, rotation); // Quaternion.identity);
            }

            isEnabled = true;
        }
       
    }
}
