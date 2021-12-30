using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoints = 2;
    [SerializeField] new ParticleSystem particleSystem;

    Animator anim;
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
        anim = GetComponent<Animator>();
     //   anim.SetBool("isDead", true);

    }
    void Update()
    {
      //  anim.SetBool("isDead", true);
        if (isDead)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, 1f), angleDirection) ;
            gameObject.transform.localScale += new Vector3(-0.005f, -0.005f, 0f);
            

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet" && hitPoints <= 0)
        {
            anim.SetBool("isDead", true);
            FindObjectOfType<GameSession>().AddScore(10);
            var getCollider = gameObject.GetComponent<CircleCollider2D>();
            getCollider.enabled = false;
            isDead = true;
            PlayParticleHit();
            Destroy(gameObject, delayTime);

        } else
        {
            hitPoints--;
        }
    }


    void PlayParticleHit()
    {
        particleSystem.Play();
    }
}
