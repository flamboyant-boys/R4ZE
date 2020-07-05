using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode : MonoBehaviour
{
    public int MoveSpeed = 2;

    public void Move(string direction)
    {
        switch(direction)
        {
            case "UP":
                transform.position += new Vector3(0, 1, 0) * MoveSpeed;
                break;
            case "DOWN":
                transform.position += new Vector3(0, -1, 0) * MoveSpeed;
                break;
            case "LEFT":
                transform.position += new Vector3(-1, 0, 0) * MoveSpeed;
                break;
            case "RIGHT":
                transform.position += new Vector3(1, 0, 0) * MoveSpeed;
                break;
        }
    }
}
