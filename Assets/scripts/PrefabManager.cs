using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance { get; private set; }
    public SEnemies Enemies;
    public SProjectiles Projectiles;
    public SEffects Effects;

    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public struct SEnemies
    {
        public GameObject Guard;
    }

    [System.Serializable]
    public struct SProjectiles
    {
        public GameObject Rifle;
    }

    [System.Serializable]
    public struct SEffects
    {
        public GameObject BulletSplash;
        public GameObject BloodSplatter;
    }
}
