using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject _impactEffect;
    
    private void Start()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (_impactEffect != null)
        {
            Instantiate(_impactEffect, transform.position, transform.rotation);
        }

        print(hitInfo.name);
        Destroy(gameObject);
    }
}
