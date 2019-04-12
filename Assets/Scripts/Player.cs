using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 100;
    public float speed = 0.05f;

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = (Input.GetAxis("Horizontal"));
        float moveVertical = (Input.GetAxis("Vertical"));

        transform.Translate(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

        if(health < 100)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Poison");
        //Display text saying "Danger"
    }

    private void OnTriggerStay(Collider other)
    {
        health -= 1;
        Debug.Log("Losing Health");
    }
}
