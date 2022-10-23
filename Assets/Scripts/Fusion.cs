using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{
    public PlantMaster pm;

    public Crops crop1;
    public Crops crop2;

    PlantMaster.Plant plant1;
    PlantMaster.Plant plant2;
    // Start is called before the first frame update
    void Start()
    {
        crop1.plants = plant1;
        crop2.plants = plant2;

        pm = FindObjectOfType<PlantMaster>();
    }
    void Fusionplant()
    {
        string type = plant1.type + Random.Range(0, 2000);
        float change = (plant1.timeToChange + plant2.timeToChange)/2;
        List<Sprite> sprites = plant1.stages;
        float growth = (plant1.growthspeed + plant2.growthspeed) / 2;

        AnimationCurve BothCurve = new AnimationCurve(
            new Keyframe[3] 
            { 
                new Keyframe(plant1.growthOnLight[0].time,   (plant1.growthOnLight[0].value + plant2.growthOnLight[0].value) / 2, (plant1.growthOnLight[0].inTangent + plant2.growthOnLight[0].inTangent) / 2, (plant1.growthOnLight[0].outTangent + plant2.growthOnLight[0].outTangent) / 2, (plant1.growthOnLight[0].inWeight + plant2.growthOnLight[0].inWeight) / 2, (plant1.growthOnLight[0].outWeight + plant2.growthOnLight[0].outWeight) / 2),
                new Keyframe(plant1.growthOnLight[1].time,   (plant1.growthOnLight[1].value + plant2.growthOnLight[1].value) / 2, (plant1.growthOnLight[1].inTangent + plant2.growthOnLight[1].inTangent) / 2, (plant1.growthOnLight[1].outTangent + plant2.growthOnLight[1].outTangent) / 2, (plant1.growthOnLight[1].inWeight + plant2.growthOnLight[1].inWeight) / 2, (plant1.growthOnLight[1].outWeight + plant2.growthOnLight[1].outWeight) / 2), 
                new Keyframe(plant1.growthOnLight[2].time,   (plant1.growthOnLight[2].value + plant2.growthOnLight[2].value) / 2, (plant1.growthOnLight[2].inTangent + plant2.growthOnLight[2].inTangent) / 2, (plant1.growthOnLight[2].outTangent + plant2.growthOnLight[2].outTangent) / 2, (plant1.growthOnLight[2].inWeight + plant2.growthOnLight[2].inWeight) / 2, (plant1.growthOnLight[2].outWeight + plant2.growthOnLight[2].outWeight) / 2)
                //new Keyframe(plant1.growthOnLight[3].time,   (plant1.growthOnLight[3].value + plant2.growthOnLight[3].value) / 2, (plant1.growthOnLight[3].inTangent + plant2.growthOnLight[3].inTangent) / 2, (plant1.growthOnLight[3].outTangent + plant2.growthOnLight[3].outTangent) / 2, (plant1.growthOnLight[3].inWeight + plant2.growthOnLight[3].inWeight) / 2, (plant1.growthOnLight[3].outWeight + plant2.growthOnLight[3].outWeight) / 2),
                //new Keyframe(plant1.growthOnLight[4].time,   (plant1.growthOnLight[4].value + plant2.growthOnLight[4].value) / 2, (plant1.growthOnLight[4].inTangent + plant2.growthOnLight[4].inTangent) / 2, (plant1.growthOnLight[4].outTangent + plant2.growthOnLight[4].outTangent) / 2, (plant1.growthOnLight[4].inWeight + plant2.growthOnLight[4].inWeight) / 2, (plant1.growthOnLight[4].outWeight + plant2.growthOnLight[4].outWeight) / 2),
                //new Keyframe(plant1.growthOnLight[5].time,   (plant1.growthOnLight[5].value + plant2.growthOnLight[5].value) / 2, (plant1.growthOnLight[5].inTangent + plant2.growthOnLight[5].inTangent) / 2, (plant1.growthOnLight[5].outTangent + plant2.growthOnLight[5].outTangent) / 2, (plant1.growthOnLight[5].inWeight + plant2.growthOnLight[5].inWeight) / 2, (plant1.growthOnLight[5].outWeight + plant2.growthOnLight[5].outWeight) / 2)
            }
        );
        Color suncol = Color.Lerp(crop1.plants.Suncol, crop2.plants.Suncol, .5f);
        
        bool needwater;
        if (plant1.needWater && plant2.needWater)
        {
            needwater = true;
        }else if (!plant1.needWater && !plant2.needWater)
        {
            needwater = false;
        }
        else
        {
            int ghjf = Random.Range(0, 1);
            if(ghjf == 1)
            {
                needwater = true;
            }
            else
            {
                needwater = false;
            }
        }
        float waterTime = (plant1.waterTime + plant2.waterTime) / 2;
        Color watercol = Color.Lerp(crop1.plants.watercol, crop2.plants.watercol, .5f);

        float dropRate = (plant1.dropRate + plant2.dropRate) / 2;
        Color dropcol = Color.Lerp(crop1.plants.dropcol, crop2.plants.dropcol, .5f);

        string soiltype = plant1.soilType;
        float soilspeed = (plant1.soilSpeed + plant2.soilSpeed) / 2;
        Color soilcol = Color.Lerp(crop1.plants.soilcol, crop2.plants.soilcol, .5f);

        float mutachance = (plant2.mutationChance + plant1.mutationChance) / 2;
        Color mutcol = Color.Lerp(crop1.plants.mutationcol, crop2.plants.mutationcol, .5f);

        float sellprice = (plant1.sellPrice + plant2.sellPrice) / 2;
        float purchase = (plant1.purchasePrice + plant2.purchasePrice) / 2;


        pm.CreatePlant(type, change, sprites, growth, BothCurve, suncol, needwater, waterTime, watercol, dropRate, dropcol, soiltype, soilspeed,soilcol,mutachance,mutcol,sellprice,purchase) ;

    }
    // Update is called once per frame
    void Update()
    {
        /*if(crop2 == null)
        {
        crop1 = GameObject.Find("GrassBlock -1 0").GetComponent<Crops>();
        crop2 = GameObject.Find("GrassBlock 1 0").GetComponent<Crops>();
        }*/
        plant1 = crop1.plants;
        plant2 = crop2.plants;
        if (Input.GetKeyDown(KeyCode.O))
        {
            Fusionplant();
        }
    }
}
