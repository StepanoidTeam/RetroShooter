﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameController.Score += 10;
        }

    }
}
