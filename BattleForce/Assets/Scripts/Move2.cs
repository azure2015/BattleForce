using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move2 : MonoBehaviour
{

    [SerializeField] GameObject bottomLevel;
    [SerializeField] GameObject topLevel;
   

    Vector2 rawInput;

    float minXPos = -5.4f; // -3.2f;
    float maxXPos = 4.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Top : " + topLevel.transform.position.y);
        if ((transform.position.x <= minXPos && rawInput.x <0 ))
        {
            rawInput.x = 0;
        }


        if (transform.position.x >= maxXPos && rawInput.x >0)
        {
            rawInput.x = 0;
        }

        if (transform.position.y >= topLevel.transform.position.y && rawInput.y >0)
        {
            rawInput.y = 0;
        }

        if (transform.position.y <= bottomLevel.transform.position.y  && rawInput.y < 0  )
        {
                rawInput.y = 0;
        }

        Vector3 delta = rawInput * 4.0f * Time.deltaTime;
        transform.position += delta;

    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
