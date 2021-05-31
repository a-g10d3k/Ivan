using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsOverrideTrigger : MonoBehaviour
{
    public Vector2 Controls;
    public bool OnlyOnce = true;
    public bool DisableOverride = false;
    private bool _trigerred = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_trigerred)
        {
            CutsceneManager.Instance.OverridePlayerControls(DisableOverride ? null : (Vector2?)Controls);
            _trigerred = OnlyOnce ? true : false;
        }
    }
}
