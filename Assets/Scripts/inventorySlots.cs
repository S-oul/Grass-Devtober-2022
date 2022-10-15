using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class inventorySlots : MonoBehaviour
{
    GameMaster gm;
    PlantMaster pm;
    PlantMaster.Plant plants = null;
    public string planteType;


    [Space]
    public bool reset;
    public void OnValidate()
    {
        //print(gameObject.name);
        planteType = gameObject.name;
        gm = FindObjectOfType<GameMaster>();
        pm = FindObjectOfType<PlantMaster>();
        foreach (PlantMaster.Plant plant in pm.list)
        {
            if (plant.type == planteType)
            {
                plants = plant;
                break;
            }

        }
        var sun = transform.GetChild(0).GetComponent<Image>();
        sun.color = plants.Suncol;
        var water = transform.GetChild(1).GetComponent<Image>();
        water.color = plants.watercol;
        var drop = transform.GetChild(2).GetComponent<Image>();
        drop.color = plants.dropcol;
        var soil = transform.GetChild(3).GetComponent<Image>();
        soil.color = plants.soilcol;
        var mut = transform.GetChild(4).GetComponent<Image>();
        mut.color = plants.mutationcol;
    }  

    // Update is called once per frame
    public void ChangeType()
    {
        gm.type = planteType;
        gm.youlldrop = gameObject;
    }
}
