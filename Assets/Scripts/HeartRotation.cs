﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotation : MonoBehaviour
{

    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Rotates the heart
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
