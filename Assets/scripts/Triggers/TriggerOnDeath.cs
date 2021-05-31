using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnDeath : MonoBehaviour
{
    public GameObject ObjectToTrigger;

    public void Trigger()
    {
        ITriggerable component = ObjectToTrigger.GetComponent<ITriggerable>();
        if(component != null)
        {
            component.Trigger();
        }
    }
}
