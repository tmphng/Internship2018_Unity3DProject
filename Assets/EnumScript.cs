using UnityEngine;
using System.Collections;

public class EnumScript : MonoBehaviour
{
    enum Direction { North, East, South, West };

    void Start()
    {
        Direction myDirection;

        myDirection = Direction.North;
        Debug.Log(myDirection);
        ReverseDirection(myDirection);
        Debug.Log(myDirection);
    }

    Direction ReverseDirection(Direction dir)
    {
        if (dir == Direction.North)
            dir = Direction.South;
        else if (dir == Direction.South)
            dir = Direction.North;
        else if (dir == Direction.East)
            dir = Direction.West;
        else if (dir == Direction.West)
            dir = Direction.East;

        return dir;
    }
}