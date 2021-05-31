using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnTrigger : MonoBehaviour, ITriggerable
{
    public GameObject GameObject;

    public void Trigger()
    {
        GameObject.SetActive(!GameObject.activeSelf);
    }
}
