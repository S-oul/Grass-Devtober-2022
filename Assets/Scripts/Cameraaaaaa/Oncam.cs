using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncam : MonoBehaviour
{
    public float time;
    public float shakeForce = .5f;
    public float precy;
    float overtime = 0;
    void Start()
    {
        
    }
    public void makeShake(float shake, float datime)
    {
        shakeForce = shake;
        time = datime;
    }
    // Update is called once per frame
    void Update()
    {

        if (time > 0)
        {
            overtime += precy;

            transform.position += new Vector3(Mathf.Sin(overtime) * shakeForce,Mathf.Sin(overtime)*shakeForce, 0);
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
            overtime = 0;
            transform.localPosition = new Vector3(0, .02f, -1);
        }
    }
}
