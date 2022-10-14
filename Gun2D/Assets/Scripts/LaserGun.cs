using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun
{
    [SerializeField] private LineRenderer _laser;
    [SerializeField] private GameObject _impactEffect;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }
    
    public IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);

        if (hitInfo)
        {
            print(hitInfo.transform.name + " is attacked");
            
            _laser.SetPosition(0, _firePoint.position);
            _laser.SetPosition(1, hitInfo.point);
        }
        else
        {
            _laser.SetPosition(0, _firePoint.position);
            _laser.SetPosition(1, _firePoint.position + _firePoint.right * 100);
        }

        _laser.enabled = true;

        yield return new WaitForSeconds(0.02f);
        
        _laser.enabled = false;

        if (_impactEffect != null)
        {
            Instantiate(_impactEffect, hitInfo.point, Quaternion.identity);
        }
    }
    
}
