using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{
    void Start()
    {
        CutsceneManager.Instance.Player.transform.position = transform.position;
    }

}
