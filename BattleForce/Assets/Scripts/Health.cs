using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hitPoints;
    [SerializeField] ParticleSystem particleSystem;

    float delayTime = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            PlayParticleHit();
            Destroy(gameObject, delayTime);

        }
    }

    void PlayParticleHit()
    {
        particleSystem.Play();
    }
}
