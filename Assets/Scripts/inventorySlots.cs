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
    public GameObject drapme;

    Color sun;
    Color water;
    Color drop;
    Color soil;
    Color mut ;


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
        sun   = plants.Suncol;
        water = plants.watercol;
        drop  = plants.dropcol;
        soil  = plants.soilcol;
        mut   = plants.mutationcol;
        print(plants);
    }  

    // Update is called once per frame
    public void ChangeType()
    {
        gm.type = planteType;

        gm.youllDrop.Suncol   = plants.Suncol;
        gm.youllDrop.Watercol = plants.watercol;
        gm.youllDrop.Dropcol  = plants.dropcol;
        gm.youllDrop.Soilcol  = plants.soilcol;
        gm.youllDrop.Mutcol   = plants.mutationcol;
    }
}
