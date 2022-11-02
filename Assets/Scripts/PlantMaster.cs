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
/*          print(inv.gameObject);*/
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
    public PlantMaster.Plant CreatePlant(string type, float change, List<Sprite> sprites, float growth, AnimationCurve growthcurve,  Color suncol, bool needwater, float watertime, Color watercol, float droprate, Color dropcol, string soiltype, float soilspeed, Color soilcol, float mutachance, Color mutcol, float sellprice, float purchprice)
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
        return newplant;
    }
    public PlantMaster.Plant RandomePlant(PlantMaster.Plant MPlant)
    {
        Plant newplant = new Plant();
        newplant.type = MPlant.type + Random.Range(0, 20000);
        newplant.timeToChange = Random.Range(5,100);
        newplant.stages = MPlant.stages;

        newplant.growthspeed = Random.Range(.5f,2);

        float Rval = Random.Range(-.05f, .05f);
        AnimationCurve BothCurve = new AnimationCurve(
           new Keyframe[3]
           {
                new Keyframe(MPlant.growthOnLight[0].time,   MPlant.growthOnLight[0].value +Random.Range(-.05f,.05f), MPlant.growthOnLight[0].inTangent+Random.Range(-.005f,.005f) , MPlant.growthOnLight[0].outTangent+Random.Range(-.005f,.005f) , MPlant.growthOnLight[0].inWeight , MPlant.growthOnLight[0].outWeight),
                new Keyframe(MPlant.growthOnLight[1].time,   MPlant.growthOnLight[1].value +Rval, MPlant.growthOnLight[1].inTangent+Random.Range(-.005f,.005f) , MPlant.growthOnLight[1].outTangent+Random.Range(-.005f,.005f) , MPlant.growthOnLight[1].inWeight , MPlant.growthOnLight[1].outWeight),
                new Keyframe(MPlant.growthOnLight[2].time,   MPlant.growthOnLight[2].value +Random.Range(-.05f,.05f), MPlant.growthOnLight[2].inTangent+Random.Range(-.005f,.005f) , MPlant.growthOnLight[2].outTangent+Random.Range(-.005f,.005f) , MPlant.growthOnLight[2].inWeight , MPlant.growthOnLight[2].outWeight)
           }
        );

        newplant.growthOnLight = BothCurve;

        Rval *= 20;
        Rval = (Rval + 1) / 2;
        float H;
        float S;
        float V;
        Color.RGBToHSV(MPlant.Suncol, out H, out S, out V);
        newplant.Suncol = Color.HSVToRGB(H, Rval, V);
        newplant.sun = Resources.Load<Sprite>("Seeds/Sun");


        newplant.needWater = false;
        newplant.waterTime = MPlant.waterTime;
        Color.RGBToHSV(MPlant.watercol, out H, out S, out V);
        newplant.watercol = Color.HSVToRGB(H, S, V);
        newplant.water = Resources.Load<Sprite>("Seeds/Water");

        newplant.dropRate = MPlant.dropRate;
        Color.RGBToHSV(MPlant.dropcol, out H, out S, out V);
        newplant.dropcol = Color.HSVToRGB(H, S, V);
        newplant.drop = Resources.Load<Sprite>("Seeds/Drop");

        newplant.soilType = MPlant.soilType;
        newplant.soilSpeed = MPlant.soilSpeed;
        Color.RGBToHSV(MPlant.soilcol, out H, out S, out V);
        newplant.soilcol = Color.HSVToRGB(H, S, V);
        newplant.soil = Resources.Load<Sprite>("Seeds/Soil");

        newplant.mutationChance = MPlant.mutationChance;
        Color.RGBToHSV(MPlant.mutationcol, out H, out S, out V);
        newplant.mutationcol = Color.HSVToRGB(H, S, V);
        newplant.mutation = Resources.Load<Sprite>("Seeds/Mutation");

        newplant.sellPrice = Mathf.RoundToInt(Rval *100);
        newplant.purchasePrice = Mathf.RoundToInt(Rval*200);

        //list.Add(newplant);
        return newplant;
    }
}
