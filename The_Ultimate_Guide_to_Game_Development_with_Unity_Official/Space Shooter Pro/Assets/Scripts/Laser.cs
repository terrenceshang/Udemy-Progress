﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up);
        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
