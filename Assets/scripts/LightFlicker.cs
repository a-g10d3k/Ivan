using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public float Frequency;
    public float MinIntensity;
    public float SwitchChance;
    private int _direction = -1;
    private float _startIntensity;
    private Light2D _light;

    private void Start()
    {
        _light = gameObject.GetComponent<Light2D>();
        _startIntensity = _light.intensity;
        InvokeRepeating("TurnOffRandomly", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        OscilateIntensity();
    }

    void OscilateIntensity()
    {
        if (_light.intensity <= MinIntensity / _startIntensity) { _direction = 1; }
        else if (_light.intensity >= _startIntensity) { _direction = -1; }

        _light.intensity += (Frequency/1) * Time.deltaTime * _direction * Random.Range(0.5f,1f);
    }

    void TurnOffRandomly()
    {
        if (Random.Range(0f, 1f) < SwitchChance) { _light.enabled = !_light.enabled; }
    }
}
