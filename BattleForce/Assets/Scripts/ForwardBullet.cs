using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBullet : MonoBehaviour
{

    [SerializeField] Transform barrel;
    [SerializeField] Rigidbody2D bullet;
    // Start is called before the first frame update

    float timeDelay = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay < 0)
        {
            var firedBullet = Instantiate(bullet, barrel.position, barrel.rotation); 
            firedBullet.AddForce(barrel.up * 224.0f);
            timeDelay = 5.0f;
        }
    }
}
