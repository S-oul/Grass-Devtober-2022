using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adder : MonoBehaviour
{
    public GameObject truc;
    inventorySlots sluts;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Add(string namer)
    {
        var go = Instantiate(truc);
        go.transform.parent = transform;
        go.name = namer;
        sluts = go.GetComponent<inventorySlots>();
        sluts.planteType = namer;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
