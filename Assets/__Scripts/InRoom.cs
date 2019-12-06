using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoom : MonoBehaviour
{
    static public float Room_W = 16;
    static public float Room_H = 11;
    static public float Wall_T = 2;

    [Header("Set in Inspector")]
    public bool keepInRoom = true;
    public float gridMult = 1;

    void LateUpdate()
    {
        if (keepInRoom)
        {
            Vector2 rPos = roomPos;
            rPos.x = Mathf.Clamp(rPos.x, Wall_T, Room_W - 1 - Wall_T);
            rPos.y = Mathf.Clamp(rPos.y, Wall_T, Room_H - 1 - Wall_T);
            roomPos = rPos;

        }
    }

    public Vector2 roomPos
    {
        get
        {
            Vector2 tPos = transform.position;
            tPos.x %= Room_W;
            tPos.y %= Room_H;
            return tPos;
        }
        set
        {
            Vector2 rm = roomNum;
            rm.x *= Room_W;
            rm.y *= Room_H;
            rm += value;
            transform.position = rm;

        }
    }

    public Vector2 roomNum
    {
        get
        {
            Vector2 tPos = transform.position;
            tPos.x = Mathf.Floor(tPos.x / Room_W);
            tPos.y = Mathf.Floor(tPos.y / Room_H);
            return tPos;
        }
        set
        {
            Vector2 rPos = roomPos;
            Vector2 rm = value;
            rm.x *= Room_W;
            rm.y *= Room_H;
            transform.position = rm + rPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
