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


    Image Exte;
    Image Mid;
    Image Inte;
    [Space]
    public bool reset;
    void OnValidate()
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
            else
            {
                //print("none");
            }
        }
        Exte = transform.GetChild(0).GetComponent<Image>();
        Exte.color = plants.colExte;

        Mid = transform.GetChild(1).GetComponent<Image>();
        Mid.color = plants.colMid;

        Inte = transform.GetChild(2).GetComponent<Image>();
        Inte.color = plants.colInte;
    }  

    // Update is called once per frame
    public void ChangeType()
    {
        gm.type = planteType;
        //print(gm.type);
    }
}
