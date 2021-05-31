using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameTrigger : MonoBehaviour, ITriggerable
{
    public void Trigger()
    {
        Application.Quit();
    }
}
