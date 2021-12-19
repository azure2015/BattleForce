using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hitPoints;
    [SerializeField] ParticleSystem particleSystem;

    float delayTime = 0.5f;
    float angleDirection = 0.5f;
    bool isDead = false;

    void Start()
    {
        float randomNumber = Random.Range(1, 3);
        if(randomNumber >1)
        {
            angleDirection = -0.5f;
        }
    }
    void Update()
    {
        if(isDead)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, 1f), angleDirection) ;
            gameObject.transform.localScale += new Vector3(-0.005f, -0.005f, 0f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            var getCollider = gameObject.GetComponent<CircleCollider2D>();
            getCollider.enabled = false;
            isDead = true;
            PlayParticleHit();
            Destroy(gameObject, delayTime);

        }
    }

    void PlayParticleHit()
    {
        particleSystem.Play();
    }
}