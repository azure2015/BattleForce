using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = -0.025f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position= new Vector2(0f,transform.position.y + scrollSpeed* Time.deltaTime);        
    }
}
