using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RiffleGun : Gun
{
    [SerializeField] private GameObject _bulletPrefab;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }

}
