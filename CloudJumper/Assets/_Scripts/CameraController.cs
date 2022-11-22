using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    public Transform target;

    public Transform bg1;

    public Transform bg2;

    private float size;

    private Vector3 cameraTargetPos = new Vector3();
    private Vector3 bg1TargetPos = new Vector3();
    private Vector3 bg2TargetPos = new Vector3();

    private void Start()
    {
        size = bg1.GetComponent<BoxCollider>().size.y;
    }


    void FixedUpdate()
    {
        //Camera
        Vector3 targetPos = SetPos(cameraTargetPos, target.position.x, target.position.y, target.position.z - 20);

        transform.position = targetPos;
        //Background
        if (transform.position.y >= bg2.position.y)

        {
            bg1.position = SetPos(bg1TargetPos, bg1.position.x, bg2.position.y, bg1.position.z);
            SwitchBg();

        }

        if (transform.position.y >= bg1.position.y)

        {
            bg1.position = SetPos(bg2TargetPos, bg2.position.x, bg1.position.y, bg2.position.z);
            SwitchBg();
        }
    }

    private void SwitchBg()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

    private Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
