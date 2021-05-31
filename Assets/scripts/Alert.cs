using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Alert : MonoBehaviour, ITriggerable
{
    public List<Light2D> Lights = new List<Light2D>();

    public void Trigger()
    {
        foreach (var light in Lights)
        {
            light.color = new Color(1, 0, 0);
        }
        gameObject.GetComponent<AudioSource>().Play();
    }
}
