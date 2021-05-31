using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]private int _health;
    public int Health { get { return _health; } set { DealDamage(_health - value); } }
    public bool HasBlood;
    public DeathHandler DeathHandler;

    void DealDamage(int dmg)
    {
        _health -= dmg;
        if (_health <= 0) { Die(); }
        TriggerOnDeath deathTrigger = gameObject.GetComponent<TriggerOnDeath>();
        if (deathTrigger != null)
        {
            deathTrigger.Trigger();
        }
    }

    void Die()
    {
        DeathHandler.Die();
    }
}
