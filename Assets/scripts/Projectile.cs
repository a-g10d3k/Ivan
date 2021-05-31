using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        if (healthSystem == null)
        {
            var splash = Object.Instantiate(PrefabManager.Instance.Effects.BulletSplash, collision.GetContact(0).point, Quaternion.identity) as GameObject;
            Destroy(splash, 1f);
            Destroy(gameObject);
            return;
        }

        healthSystem.Health -= damage;
        if (healthSystem.HasBlood)
        {
            Object.Instantiate(PrefabManager.Instance.Effects.BloodSplatter, collision.GetContact(0).point, transform.rotation);
        }
        Destroy(gameObject);
        return;
    }
}
