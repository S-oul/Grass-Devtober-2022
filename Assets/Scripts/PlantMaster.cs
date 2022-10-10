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
        [Space]
        [Header("Exterieur")]
        public Sprite Exte;
        public Color colExte;
        public int speedGrowth;
        [Space]
        [Header("Milieu")]
        public Sprite Mid ;
        public Color colMid;
        public int mutationChances;

        [Space]
        [Header("Interieur")]
        public Sprite Inte;
        public Color colInte;
        public int effects;
        [Space]
        [Header("Statistics")]
        public int dropMore;
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
