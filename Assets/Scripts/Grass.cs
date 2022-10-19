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
        if (Input.GetMouseButtonUp(0))
        {
            crops.planteType = gm.type;
            crops.Planter();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
