using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public float speed = 0.05f;
    public float jumpStrength = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float moveHorizontal = (Input.GetAxis("Horizontal"));
        float moveVertical = (Input.GetAxis("Vertical"));

        transform.Translate(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

        //Jump

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered the Poison Zone");
        //have text come up saying "Get Out"
    }

    private void OnTriggerStay(Collider other)
    {
        health -= 1;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited the Poison Zone");
    }
}
