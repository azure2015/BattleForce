using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBullet : MonoBehaviour
{

    [SerializeField] Transform barrel;
    [SerializeField] Rigidbody2D bullet;
    // Start is called before the first frame update

    float timeDelay = .5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay < 0)
        {
            //    Quaternion angleToFire = Quaternion.Euler(0, 0, barrel.rotation.z + 180f);
            //  barrel.transform.Rotate(0, 0, 180f);
     //       Debug.Log("Bullet dir " + barrel.rotation);
            var firedBullet = Instantiate(bullet, barrel.position, barrel.rotation); 
            firedBullet.AddForce(barrel.up * 224.0f);
            timeDelay = Random.Range(0.3f,0.8f);
        }
    }
}
