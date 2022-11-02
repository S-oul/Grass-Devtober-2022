using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;



public class SHOPTESTER : MonoBehaviour
{
    GameMaster gm; 
    PlantMaster pm;
    Adder add;
    public TextMeshProUGUI moneytext;
    GameObject dumoment;
    PlantMaster.Plant plantduMo;
    public inventorySlots prems;
    // Start is called before the first frame update
    void Start()
    {
        add = FindObjectOfType<Adder>();
        gm = FindObjectOfType<GameMaster>();
        pm = FindObjectOfType<PlantMaster>();
    }
    void Awake()
    {
        add = FindObjectOfType<Adder>();
        gm = FindObjectOfType<GameMaster>();
        pm = FindObjectOfType<PlantMaster>();
    }
    public void DisplayPlant(PlantMaster.Plant plant)
    {
        plantduMo = plant;
        dumoment = Resources.Load<GameObject>("Seeds/Wheat1");
        dumoment.transform.GetChild(0).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Sun");
        dumoment.transform.GetChild(1).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Water");
        dumoment.transform.GetChild(2).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Drop");
        dumoment.transform.GetChild(3).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Soil");
        dumoment.transform.GetChild(4).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Mutation");

        dumoment.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = plant.Suncol;
        dumoment.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = plant.watercol;
        dumoment.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = plant.dropcol;
        dumoment.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = plant.soilcol;
        dumoment.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = plant.mutationcol;
        string yolo = "" + plant.purchasePrice;
        moneytext.text = yolo;


    }
    public void Purcharplant()
    {
        if(gm.money >= plantduMo.purchasePrice)
        {
            gm.RemoveMoney((int)plantduMo.purchasePrice);
            foreach (PlantMaster.Plant plant in pm.list)
            {
                if(plant.type == plantduMo.type)
                {
                    prems.howmANYHAVEIIII++;
                    return;
                }
            }
            pm.list.Add(plantduMo);
            add.Add(plantduMo.type, true);
        }
    }
}
