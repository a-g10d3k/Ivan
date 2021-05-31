using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public SGunshots Gunshots;
    public SDeaths Deaths;
    public SMisc Misc;

    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public struct SGunshots
    {
        public AudioClip Rifle;
        public AudioClip Shell;
    }
    [System.Serializable]
    public struct SDeaths
    {
        public AudioClip Guard;
    }
    [System.Serializable]
    public struct SMisc
    {
        public AudioClip Step;
    }
}
