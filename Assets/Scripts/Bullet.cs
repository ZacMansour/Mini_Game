using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        //Destroy bullet so it won't last too long
        Destroy(gameObject, 2f);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
    }
}
