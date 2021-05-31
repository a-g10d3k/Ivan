using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public CutsceneManager.Cutscene Cutscene;
    public bool OnlyOnce = true;
    private bool _trigerred = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !_trigerred)
        {
            CutsceneManager.Instance.InitiateCutscene(Cutscene.CutsceneData);
            _trigerred = OnlyOnce ? true : false;
        }
    }
}
