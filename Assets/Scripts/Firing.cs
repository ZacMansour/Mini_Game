using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject gun;
    public GameObject projectile;
    public Rigidbody bullet;
    public Transform firingPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
        }
    }
}
