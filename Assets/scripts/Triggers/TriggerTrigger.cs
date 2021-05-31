using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrigger : MonoBehaviour
{
    public GameObject ObjectToTrigger;
    public bool OnlyOnce = true;
    private bool _trigerred = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_trigerred)
        {
            ITriggerable component = ObjectToTrigger.GetComponent<ITriggerable>();
            if(component != null) { component.Trigger(); }
            _trigerred = OnlyOnce ? true : false;
        }
    }
}
