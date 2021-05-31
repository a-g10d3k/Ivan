using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Thunder : MonoBehaviour, ITriggerable
{
    private Light2D _globalLight;
    private bool _decrease;

    private void Update()
    {
        if (_decrease)
        {
            _globalLight.intensity -= Time.deltaTime * 10;
            if(_globalLight.intensity <= 0.5f)
            {
                _decrease = false;
                _globalLight.intensity = 0.5f;
            }
        }
    }

    private void Start()
    {
        _globalLight = GameObject.FindGameObjectWithTag("Global light").GetComponent<Light2D>();
    }

    public void Trigger()
    {
        _globalLight.intensity = 10f;
        gameObject.GetComponent<AudioSource>().Play();
        _decrease = true;
    }
}
