using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welp : MonoBehaviour
{
    float timepassed = 0;
    public float amplitude;
    bool isPick = false;
    public Transform recup;
    bool timing = false;
    int cycles;
    inventorySlots sluuts;
    public string type;
    inventorySlots[] gol;
    void Start()
    {
        gol = Resources.FindObjectsOfTypeAll<inventorySlots>();
        foreach (inventorySlots inv in gol)
        {
            if (inv.gameObject.name == type)
            {
                sluuts = inv;
                break;
            }
        }
        recup = GameObject.Find("RECUP").transform;
    }
    void Awake()
    {
        gol = Resources.FindObjectsOfTypeAll<inventorySlots>();
        foreach (inventorySlots inv in gol)
        {
            if (inv.gameObject.name == type)
            {
                sluuts = inv;
                break;
            }
        }
        recup = GameObject.Find("RECUP").transform;
    }
    private void OnMouseEnter()
    {
        if (timing)
        {
            isPick = true;
        }
    }
    void Update()
    {
        if (timepassed > .3f)
        {
            timing = true;
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        timepassed += Time.deltaTime;
        if(timepassed > 1 && GetComponent<Rigidbody>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
        if (timepassed <= Mathf.PI * 2)
        {

            transform.position += new Vector3(0, Mathf.Sin(timepassed), 0) * amplitude;
            transform.eulerAngles += new Vector3(0, amplitude * 1000, 0);
        }
        else if (cycles > 5)
        {
            Destroy(gameObject);
        }
        else
        {
            cycles++;
            timepassed = 0;
        }


        if (isPick)
        {
            //Debug.LogError("caca");
            transform.position += (new Vector3((recup.position.x - transform.position.x)/10, .01f, (recup.position.z - transform.position.z)/10).normalized) / 10;
            if (Vector3.Distance(transform.position, recup.position) < .5f)
            {
                sluuts.gameObject.SetActive(true);
                if(sluuts.howmANYHAVEIIII < 9)
                {
                    sluuts.howmANYHAVEIIII += 1;
                }
                Destroy(gameObject);
            }
        }



    }
}
