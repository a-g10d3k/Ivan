using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : DeathHandler
{
    public Sprite DeathSprite;
    public override void Die()
    {
        CutsceneManager.Instance.OverridePlayerControls(new Vector2(0,0));
        CutsceneManager.Instance.FadeToBlack = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = DeathSprite;
        gameObject.GetComponent<Animator>().enabled = false;
        Invoke("Revive", 1f);
    }

    private void Revive()
    {
        gameObject.GetComponent<HealthSystem>().Health = 12;
        CutsceneManager.Instance.OverridePlayerControls(null);
        CutsceneManager.Instance.FadeToBlack = false;
        gameObject.GetComponent<Animator>().enabled = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
