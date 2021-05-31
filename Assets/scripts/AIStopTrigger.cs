using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStopTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Guard")
        {
            collision.gameObject.GetComponent<GuardAI>().Direction = new Vector2(0, 0);
        }
    }
}
