using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    public Gun _gun;
    
    void Start()
    {
        _gun = new Rifle(this);
    }

    void FixedUpdate()
    {
        GunUpdate();
    }

    public virtual void GunUpdate()
    {
        if (_gun.ShootTimer > 0) { _gun.ShootTimer -= Time.fixedDeltaTime; }
        if (Input.GetAxis("Fire1") > 0 && _gun.ShootTimer <= 0) { _gun.Shoot(); }
    }
}
