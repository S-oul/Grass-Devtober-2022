using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{
    PlantMaster pm;

    public Crops crop1;
    public Crops crop2;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlantMaster>();
    }
    void Fusionplant()
    {
        string type = crop1.plants.type + Random.Range(0, 2000);
        float change = (crop1.plants.timeToChange + crop2.plants.timeToChange)/2;
        List<Sprite> sprites = crop1.plants.stages;
        float growth = (crop1.plants.growthspeed + crop2.plants.growthspeed) / 2;
        Color suncol = Color.Lerp(crop1.plants.Suncol, crop2.plants.Suncol, .5f);
        pm.CreatePlant(type, change, sprites, growth, AnimationCurve"?", suncol,);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
