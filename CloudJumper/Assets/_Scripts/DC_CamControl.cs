using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC_CamControl : MonoBehaviour
{
    public Transform target;

    public Transform bg1;

    public Transform bg2;

    private float size;

    // Start is called before the first frame update
    void Start()
    {
        size = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //camera
        Vector3 targetPos = new Vector3(0, target.position.y, target.position.z);
        
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);



        //background
        if (transform.position.y >= bg2.position.y)
        {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            Switchbg();
        }

        if(transform.position.y<bg1.position.y)
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - size, bg2.position.z);
            Switchbg();
        }

    }

    private void Switchbg()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

}
