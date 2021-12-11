using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hitPoints;

    void OnCollision2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            Debug.Log("Hit");
        }
    }
}
