using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAndMove : MonoBehaviour, ITriggerable
{
    /*
     * Fading will be implemented later
     */
    public GameObject ObjectToMove;
    public Transform Destination;
    public Vector2 DestinationPosition;

    public void Trigger()
    {
        ObjectToMove.transform.position = Destination == null ? (Vector3)DestinationPosition : Destination.position;
    }
}
