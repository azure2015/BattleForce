using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
   
    [SerializeField] int _health = 100;

    [Range(100,200)]
    [SerializeField] int maxHealth = 120;

    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value,0, maxHealth);
    }

    private void OnValidate() => Health = _health; // = Mathf.Clamp(_health, 0, maxHealth);


    public void addHealth(int newHealth) => _health = Mathf.Clamp(newHealth, 0, maxHealth);

}
