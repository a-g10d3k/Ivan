using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    private GunController _gc;
    private static GameObject _projectilePrefab = PrefabManager.Instance.Projectiles.Rifle;
    private const double _shootDelay = 0.1;

    public Rifle(GunController gc)
    {
        _gc = gc;
    }

    

    public override void Shoot()
    {
        var projectile = Object.Instantiate(_projectilePrefab, _gc.transform.position, _gc.transform.rotation) as GameObject;
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = 25 * projectile.transform.up;
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), _gc.gameObject.transform.parent.gameObject.GetComponent<Collider2D>());
        _gc.GetComponent<AudioSource>().PlayOneShot(AudioManager.Instance.Gunshots.Rifle);
        _gc.GetComponent<AudioSource>().PlayOneShot(AudioManager.Instance.Gunshots.Shell, 0.2f);
        ShootTimer = _shootDelay;
    }
}
