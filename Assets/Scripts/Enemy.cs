using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public GameObject Bullet;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    private void Start()
    {
        //The enemy's current health 
        currentHealth = startingHealth;


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            StartSinking();
        }

        //This is how fast the enemy will sink
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Bullet")
        {
            currentHealth -= 10;
            Destroy(Bullet);
        }
    }

    /*public void TakeDamage(int amount, Vector3 hitPoint)
    {
        /*If the enemy is dead there is no need to take damage
        so exit the function
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death();
        }
    }*/

    /*void Death()
    {
        isDead = true;

        /*Turn the collider into a trigger so bullets can pass through
        capsuleCollider.isTrigger = true;
    }*/

    public void StartSinking()
    {
        //Find the rigidbody component and make it kinematic
        GetComponent<Rigidbody>().isKinematic = true;

        //The enemy should sink
        isSinking = true;

        //After 2 seconds destroy enemy
        Destroy(gameObject, 2f);
    }
}
