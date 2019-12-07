using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowDray : MonoBehaviour
{
    static public bool TRANSITIONING = false;

    [Header("Set in Inspector")]
    public InRoom drayInRm;
    public float transTime = .5f;

    private Vector2 p0, p1;

    private InRoom inRm;
    private float tranStart;

    void Awake()
    {
        inRm = GetComponent<InRoom>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TRANSITIONING)
        {
            float u = (Time.time - tranStart) / transTime;
            if(u>= 1)
            {
                u = 1;
                TRANSITIONING = false;

            }
            transform.position = (1 - u) * p0 + u * p1;

        }
        else
        {
            if(drayInRm.roomNum != inRm.roomNum)
            {
                TransitionTo(drayInRm.roomNum);
            }
        }

    }

    void TransitionTo(Vector2 rm)
    {
        p0 = transform.position;
        inRm.roomNum = rm;
        p1 = transform.position + (Vector3.back * 10);
        transform.position = p0;

        tranStart = Time.time;
        TRANSITIONING = true;
    }
}
