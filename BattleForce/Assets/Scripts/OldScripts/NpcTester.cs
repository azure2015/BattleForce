using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTester : MonoBehaviour
{
    test npcTest;
    int desiredHealth = 100;

    // Update is called once per frame
    void Update()
    {
        npcTest.Health = desiredHealth;
    }
}
