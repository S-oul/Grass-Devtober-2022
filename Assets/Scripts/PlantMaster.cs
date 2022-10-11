using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlantMaster : MonoBehaviour
{
    public List<Plant> list = new List<Plant>();

    [System.Serializable]
    public class Plant
    {
        public string type;
        public float timeToChange = 0;
        public List<Sprite> stages = new List<Sprite>();
        [Header("Statistics")]
        public float dropRate;
        public float mutationChance;
        public float growthspeed;
        public AnimationCurve growthOnLight;
        public string soilType;
        public float soilSpeed;
        public float sellPrice;
        public float purchasePrice;

        [Space]
        [Header("Exterieur")]
        public Sprite Exte;
        public Color colExte;
        [Space]
        [Header("Milieu")]
        public Sprite Mid ;
        public Color colMid;
        [Space]
        [Header("Interieur")]
        public Sprite Inte;
        public Color colInte;
    }
    void OnValidate()
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i].Exte = Resources.Load<Sprite>("Seeds/Exte");
            list[i].Mid = Resources.Load<Sprite>("Seeds/Mid");
            list[i].Inte = Resources.Load<Sprite>("Seeds/Inte");
        }

    }

}
