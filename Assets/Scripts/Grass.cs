using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public GameMaster gm;
    public Crops crops;
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        crops = GetComponentInChildren<Crops>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && GameObject.Find(gm.type).GetComponent<inventorySlots>().howmANYHAVEIIII >= 1)
        {
            crops.planteType = gm.type;
            GameObject.Find(gm.type).GetComponent<inventorySlots>().howmANYHAVEIIII -= 1;
            crops.Planter(null);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
