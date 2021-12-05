using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float forwardSpeed = 0f;
    Rigidbody2D rigidbody;

    Vector2 rawInput;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * forwardSpeed);
    }
    void Update()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
      //  rigidbody.AddForce(transform.up * forwardSpeed);
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
      //  Debug.Log(rawInput);
    }
}
