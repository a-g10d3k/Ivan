using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour, ITriggerable
{
    private bool _load;
    public int Scene;

    public void Trigger()
    {
        CutsceneManager.Instance.FadeToBlack = true;
        _load = true;
    }

    private void Update()
    {
        if (_load)
        {
            if(CutsceneManager.Instance.Black.color.a > 0.99f)
            {
                CutsceneManager.Instance.FadeToBlack = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
                CutsceneManager.Instance.Player.GetComponent<HealthSystem>().Health = 12;
            }
        }
    }
}
