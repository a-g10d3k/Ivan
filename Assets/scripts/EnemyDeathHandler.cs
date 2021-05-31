using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : DeathHandler
{
    public Sprite DeathSprite;
    public bool BloodSplatter = true;
    public AudioClip DeathSound;

    public override void Die()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = DeathSprite;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        var audioSource = gameObject.GetComponent<AudioSource>();
        if (DeathSound != null && audioSource != null) { audioSource.PlayOneShot(DeathSound); }
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<GuardAI>().Gun);
        Destroy(gameObject.GetComponent<GuardAI>());
    }
}
