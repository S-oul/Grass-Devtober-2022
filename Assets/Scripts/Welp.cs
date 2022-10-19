using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welp : MonoBehaviour
{
    float timepassed = 0;
    public float amplitude;
    bool isPick = false;

    void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        isPick = true;
    }
    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        timepassed += Time.deltaTime;
        if(timepassed > 1 && GetComponent<Rigidbody>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
        if (timepassed <= Mathf.PI * 2)
        {
            
            transform.position += new Vector3(0, Mathf.Sin(timepassed), 0) * amplitude;
            transform.eulerAngles += new Vector3(0, amplitude*1000, 0);
        }
        else
        {
            //print(timepassed);
            timepassed = 0;
        }


        if (isPick)
        {
            transform.position += new Vector3(0, 0.1f, 0);
        }



    }
}
