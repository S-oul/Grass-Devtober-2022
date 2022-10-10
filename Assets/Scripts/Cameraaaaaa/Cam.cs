using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    bool left = false;
    bool right = false;

    bool changeLeft;
    bool changeRight;

    public Transform fusionTerrain;
    public Transform terrain;

    Vector3 oldPos;
    Vector3 OV3 = new Vector3(0, 90, 0);

    float timein;
    public float precy;

    public AnimationCurve TurnPos;
    public AnimationCurve TurnSpeed;
    public void changeL()
    {
        fusionTerrain.transform.parent = null;
        changeLeft = !changeLeft;
    }
    public void changeR()
    {
        terrain.transform.parent = null;
        changeRight = !changeRight;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !left && !right)
        {
            oldPos = transform.eulerAngles;

            left = true;
        }
        if (left)
        {
            timein += precy;

            transform.eulerAngles =  new Vector3(oldPos.x, oldPos.y + TurnPos.Evaluate(timein) * (TurnSpeed.Evaluate(timein)), oldPos.z) ;
            //print(oldPos.y + TurnPos.Evaluate(timein));           
            if(timein >= 1)
            {
                //print(transform.eulerAngles);
                transform.eulerAngles = oldPos + OV3;
                left = false;
                timein = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && !left && !right)
        {
            oldPos = transform.eulerAngles;

            right = true;
        }
        if (right)
        {
            timein += precy;

            transform.eulerAngles = new Vector3(oldPos.x, oldPos.y - TurnPos.Evaluate(timein) * (TurnSpeed.Evaluate(timein)), oldPos.z);
            //print(oldPos.y + TurnPos.Evaluate(timein));           
            if (timein >= 1)
            {
                //print(transform.eulerAngles);
                transform.eulerAngles = oldPos - OV3;
                right = false;
                timein = 0;
            }
        }

        if (changeLeft)
        {
            timein += precy;
            transform.position = Vector3.MoveTowards(transform.position, fusionTerrain.position, TurnSpeed.Evaluate(timein)/2);

            if (timein >= 1)
            {
                terrain.transform.parent = transform;
                changeLeft = false;
                timein = 0;
            }
        }
        if (changeRight)
        {
            timein += precy;
            transform.position = Vector3.MoveTowards( fusionTerrain.position, transform.position, TurnSpeed.Evaluate(timein) / 2);

            if (timein >= 1)
            {
                fusionTerrain.transform.parent = transform;
                changeRight = false;
                timein = 0;
            }
        }
    }
}
