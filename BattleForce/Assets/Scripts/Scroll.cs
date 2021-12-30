using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = -0.65f;
    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position= new Vector2(startPosition.x,transform.position.y + scrollSpeed* Time.deltaTime);   
        
    }

    public void Reset()
    {
        transform.position = startPosition;
    }



}
