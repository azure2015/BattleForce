using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject resetPosition;
    [SerializeField] Tilemap tilePosition;
    [SerializeField] GameObject endPosition;
    [SerializeField] ParticleSystem playerHit = null;


    [SerializeField] GameObject bottomLevel;
    [SerializeField] GameObject topLevel;

    [SerializeField] float fireRate = 0.15f;

    [SerializeField] List<Sprite> planeSprites;

    float minXPos = -4.9f; // -3.2f;
    float maxXPos = 4.4f;
    float timeSpan = 3.0f;

    int hitPoints = 3;

    bool canFire = true;
    bool isAlive = true;

    Vector2 startPosition;
    Vector2 rawInput;

    Animator anim;
    AudioSource audioSource;
    SpriteRenderer spitfireSprite;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spitfireSprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        

        if (!canFire && isAlive)
        {
          
            fireRate -= Time.deltaTime;
            if(fireRate<0)
            {
                canFire = true;
                fireRate = 0.3f;
            }
        }

        if ((transform.position.x <= minXPos && rawInput.x < 0))
        {
            rawInput.x = 0;
        }


        if (transform.position.x >= maxXPos && rawInput.x > 0)
        {
            rawInput.x = 0;
        }

        if (transform.position.y >= topLevel.transform.position.y && rawInput.y > 0)
        {
            rawInput.y = 0;
        }

        if (transform.position.y <= bottomLevel.transform.position.y && rawInput.y < 0)
        {
            rawInput.y = 0;
        }

        if (isAlive)
        {
            Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
            transform.position += delta;
        } else
        {
            timeSpan -= Time.deltaTime;
            anim.Play("Explode_new");
            if (timeSpan <= 0)
            {
                PlayerDeath();
            }
        }

        
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (canFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            canFire = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="EndLevel")
        {
            float yPos = endPosition.transform.position.y - resetPosition.transform.position.y;
            startPosition = tilePosition.transform.position;
            startPosition.y = startPosition.y + yPos;
            tilePosition.transform.position = startPosition;
   

        }
        if (collision.tag == "EnemyBullet" && hitPoints <= 0)
        {
            isAlive = false;
            anim = GetComponent<Animator>();
            anim.enabled = true;
            audioSource.Stop();
           // PlayerDeath();
        }
        else if (collision.tag == "EnemyBullet")
        {
            hitPoints--;
            spitfireSprite.sprite = planeSprites[hitPoints];
            PlayParticleHit();
            Debug.Log("Player health : " + hitPoints);

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerDeath();
        }
           
    }

    void PlayerDeath()
    {
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    void PlayParticleHit()
    {
        playerHit.Play();
    }


}
