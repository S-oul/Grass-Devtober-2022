using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDropdown : MonoBehaviour
{
    public bool dobidown = true;
    bool doit = false;
    public AnimationCurve pos;

    public RectTransform Rt;

    float precy = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dobidown == true && doit == true)
        {
            var addor = pos.Evaluate(precy);
            precy += .5f;
            Rt.transform.localPosition = new Vector3(transform.localPosition.x, addor, transform.localPosition.z);
            print(precy + "  /  " + addor);
            if (precy >= pos.keys[1].time)
            {
                Rt.transform.localPosition = new Vector3(transform.localPosition.x, 175, transform.localPosition.z);
                precy = pos.keys[1].time;
                dobidown = false;
                doit = false;
            }
        }
        if (dobidown == false && doit == true)
        {
            var addor = pos.Evaluate(precy);
            precy -= .5f;
            Rt.transform.localPosition = new Vector3(transform.localPosition.x, addor, transform.localPosition.z);
            print(precy + "  /  " + addor);
            if (precy <= pos.keys[0].time)
            {
                Rt.transform.localPosition = new Vector3(transform.localPosition.x, 650, transform.localPosition.z);
                precy = pos.keys[0].time;
                dobidown = true;
                doit = false;
            }
        }
    }
    public void Changedrop()
    {
        doit = true;
    }
}
