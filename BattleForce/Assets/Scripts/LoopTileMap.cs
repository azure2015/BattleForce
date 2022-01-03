using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTileMap : MonoBehaviour
{
    [SerializeField] GameObject startPosition;
    [SerializeField] GameObject endPosition;
    //[SerializeField] GameObject tileMap;

    float yPos;

    void Start()
    {
        yPos = startPosition.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {

         Debug.Log("End position : " + yPos);
        if (endPosition.transform.position.y < -3.0f)
        {
            transform.position = new Vector3(0,yPos,0);
         //   Debug.Log("y - axis" + tilePosition.y);

        }
    }
}
