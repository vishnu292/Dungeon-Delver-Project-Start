using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFacingMover
{
    // Start is called before the first frame update
    int GetFacing();
    bool moving { get; }
    float GetSpeed();
    float gridMult{get; }
    Vector2 roomPos { get; set; }
    Vector2 roomNum { get; set; }
    Vector2 GetRoomPosOnGrid ( float mult = -1 );
}
