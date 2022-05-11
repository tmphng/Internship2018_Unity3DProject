using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
public class EventRequest : EventTrigger {

    public override void OnMove(AxisEventData data)
    {
        Debug.Log("OnMove called.");
    }
}
*/

public class EventRequest : MonoBehaviour {

    public delegate void Moving();
    public static event Moving Movement;

    void OnMove()
    {
        if (Movement != null)
            Movement();
    }
}
