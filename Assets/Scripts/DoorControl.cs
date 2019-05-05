using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        //GameObject that is tagged Bullet opens the door
        if (other.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("DoorOpen");
            Debug.Log("Door Open");
        }
    }

}
