using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;

    bool isDead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
