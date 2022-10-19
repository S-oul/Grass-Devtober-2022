using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlantMaster : MonoBehaviour
{
    public List<Plant> list = new List<Plant>();
    inventorySlots[] invList = new inventorySlots[0];

    [System.Serializable]
    public class Plant
    {
        public string type;
        public float timeToChange = 0;
        public List<Sprite> stages = new List<Sprite>();
        [Header("Statistics")]
        public float growthspeed;

        [Header("Sun Light")]
        public AnimationCurve growthOnLight;
        public Color Suncol;
        public Sprite sun;

        [Header("Water")]
        public bool needWater;
        public float waterTime;
        public Color watercol;
        public Sprite water;

        [Header("Dropper")]
        public float dropRate;
        public Color dropcol;
        public Sprite drop;

        [Header("Soiler")]
        public string soilType;
        public float soilSpeed;
        public Color soilcol;
        public Sprite soil;

        [Header("MUTAITO")]
        public float mutationChance;
        public Color mutationcol;
        public Sprite mutation;

        [Header("other")]
        public float sellPrice;
        public float purchasePrice;
    }
    void OnValidate()
    {
        invList = FindObjectsOfType<inventorySlots>();
        foreach(inventorySlots inv in invList)
        {
            print(inv.gameObject);
            inv.OnValidate();
        }
        for(int i = 0; i < list.Count; i++)
        {
            list[i].sun = Resources.Load<Sprite>("Seeds/Sun");
            list[i].water = Resources.Load<Sprite>("Seeds/Water");
            list[i].drop = Resources.Load<Sprite>("Seeds/Drop");
            list[i].soil = Resources.Load<Sprite>("Seeds/Soil");
            list[i].mutation = Resources.Load<Sprite>("Seeds/Mutation");
        }

    }
    public void CreatePlant(string type, float change, List<Sprite> sprites, float growth, AnimationCurve growthcurve,  Color suncol, bool needwater, float watertime, Color watercol, float droprate, Color dropcol, string soiltype, float soilspeed, Color soilcol, float mutachance, Color mutcol, float sellprice, float purchprice)
    {
        Plant newplant = new Plant();
        newplant.type = type;
        newplant.timeToChange = change;
        newplant.stages = sprites;

        newplant.growthspeed = growth;

        newplant.growthOnLight = growthcurve;
        newplant.Suncol = suncol;
        newplant.sun = Resources.Load<Sprite>("Seeds/Sun");

        newplant.needWater = needwater;
        newplant.waterTime = watertime;
        newplant.watercol = watercol;
        newplant.water = Resources.Load<Sprite>("Seeds/Water");

        newplant.dropRate = droprate;
        newplant.dropcol = dropcol;
        newplant.drop = Resources.Load<Sprite>("Seeds/Drop");

        newplant.soilType = soiltype;
        newplant.soilSpeed = soilspeed;
        newplant.soilcol = soilcol;
        newplant.soil = Resources.Load<Sprite>("Seeds/Soil");

        newplant.mutationChance = mutachance;
        newplant.mutationcol = mutcol;
        newplant.mutation = Resources.Load<Sprite>("Seeds/Mutation");

        newplant.sellPrice = sellprice;
        newplant.purchasePrice = purchprice;

        list.Add(newplant);
    }
}
