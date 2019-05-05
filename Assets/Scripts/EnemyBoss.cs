using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public int startingHealth = 100;
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
        //This is how fast the enemy will sink
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //GameObject that is tagged Bullet does 10 damage
        if (collision.collider.gameObject.tag == "Bullet")
        {
            currentHealth -= 10;
            Destroy(Bullet);
        }

        //Enemy sinks when it dies
        if (currentHealth <= 0)
        {
            StartSinking();
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

        if (currentHealth <= 0)
        {
            Death();
        }
    }*/

    /*void Death()
    {
        isDead = true;

        Turn the collider into a trigger so bullets can pass through
        capsuleCollider.isTrigger = true;
    }*/

    //Makes enemy sink
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
