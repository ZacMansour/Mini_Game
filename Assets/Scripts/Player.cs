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

        if (health <= 1)
        {
            Destroy(gameObject);
            //Instantiate(gameObject, GameObject.Find("RespawnPoint").transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Danger Zone");
        //Display text saying "Danger"

        if (other.gameObject.CompareTag("HP"))
        {
            other.gameObject.SetActive(false);
            health += 10;
        }

        if (other.gameObject.CompareTag("HP+"))
        {
            other.gameObject.SetActive(false);
            health += 20;
        }
    }

    //decrease health in poison zone
    //slow down
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Losing Health");

        if (gameObject.tag == "Player")
        {
            health -= 1;
        }
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

        if (collision.collider.gameObject.tag == "Roamer")
        {
            health -= 5;
        }

        if (collision.collider.gameObject.tag == "Boss")
        {
            health -= 10;
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "HP")
        {
            Destroy(hit.gameObject);
            health += 10;
        }

        if(hit.gameObject.tag == "HP+")
        {
            Destroy(hit.gameObject);
            health += 20;
        }
    }*/
}
