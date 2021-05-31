using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public List<GameObject> GameObjects = new List<GameObject>();

    private void Awake()
    {
        foreach(GameObject o in GameObjects)
        {
            if (o != null) { DontDestroyOnLoad(o); }
        }
    }
}
