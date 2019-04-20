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

    private void OnTriggerEnter(Collider drown)
    {
        Debug.Log("Entered Danger Zone");
        //Display text saying "Danger"
    }

    private void OnTriggerStay(Collider drown)
    {
        Debug.Log("Losing Health");

        //decrease health in poison zone
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left the Danger Zone");
    }

    //destroys player when touching death pad
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }

}
