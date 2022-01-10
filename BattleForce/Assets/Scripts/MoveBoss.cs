using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{

 //   [SerializeField] int hitPoints = 20;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float minLeft = -2.8f;
    [SerializeField] float maxRight = 2.4f;

    [SerializeField] List<string> Actions = new List<string> { "Left", "Right", "Center","Left", "Right" };
    float timer = 4f;
    int currentIndex = 0;
    string currentAction;
    bool isCenter = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //        currentAction = Actions[currentIndex];
        currentAction = "Down";
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <0 )
        {
            timer = 4f;
            currentIndex = (currentIndex >= Actions.Count -1) ? 0 : currentIndex +1;  
            currentAction = Actions[currentIndex];
            isCenter = false;

        }
        timer -= Time.deltaTime;
     //   Debug.Log("Action : " + currentAction);

        switch(currentAction)
        {
            case "Left":
                moveLeft();
                break;
            case "Right":
                moveRight();
                break;
            case "Center":
                moveCenter();
                break;
            case "Down":
                moveDown();
                break;
            default:
                break;
        }

    }

    void moveLeft()
    {
        if (transform.position.x > minLeft)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void moveDown()
    {
//        if (transform.position.y < 30)
  //      {
            transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed/10) * Time.deltaTime);
    //    }
    }

    void moveRight()
    {
        if (transform.position.x < maxRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void moveCenter()
    {
  //      Debug.Log("Is Center : " + isCenter);
        if(transform.position.x < -0.2 && !isCenter )
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        } else if (transform.position.x > 0.2 && !isCenter)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        } else
        {
            isCenter = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Debug.Log("Hit plane");
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Bullet")
    //    {
    //        anim.Play("Explosion", 0, 0);
    //        hitPoints--;
    //    }
    //}
}
