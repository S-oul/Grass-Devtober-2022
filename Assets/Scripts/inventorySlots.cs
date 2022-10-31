using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class inventorySlots : MonoBehaviour
{
    GameMaster gm;
    PlantMaster pm;
    PlantMaster.Plant plants = null;
    public string planteType;
    //public GameObject drapme;

    public int howmANYHAVEIIII = 1;
    public TextMeshProUGUI tmbro;
    [Space]
    public bool reset;
    public void Start()
    {
        OnValidate();
        ChangeType();
    }
    private void Update()
    {
        if(howmANYHAVEIIII == 0)
        {
            gameObject.SetActive(false);
        }

        string yolo63 = "" + howmANYHAVEIIII;
        tmbro.text = yolo63;
    }
    public void OnValidate()
    {
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
        transform.GetChild(0).gameObject.GetComponent<Image>().color = plants.Suncol;
        transform.GetChild(1).gameObject.GetComponent<Image>().color = plants.watercol;
        transform.GetChild(2).gameObject.GetComponent<Image>().color = plants.dropcol;
        transform.GetChild(3).gameObject.GetComponent<Image>().color = plants.soilcol;
        transform.GetChild(4).gameObject.GetComponent<Image>().color = plants.mutationcol;

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
    private void Awake()
    {
        planteType = gameObject.name;
    }
}
