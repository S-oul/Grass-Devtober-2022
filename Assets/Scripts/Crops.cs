using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crops : MonoBehaviour
{
    public string planteType = null;
    PlantMaster pm;
    PlantMaster.Plant plants = null;
    public int timePassed;
    public int stageCount = 0;
    
    Oncam cam;
    public float shakeTime;
    public float shake;

    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Oncam>();

        pm = FindObjectOfType<PlantMaster>();
        col = GetComponent<BoxCollider>();
    }
    public void Planter()
    {
        col.size = Vector3.one;
        cam.makeShake(shake, shakeTime);
        foreach (PlantMaster.Plant plant in pm.list)
        {
            if (plant.type == planteType)
            {
                plants = plant;
                for (int i = 0; i < 4; i++)
                {
                    var go = gameObject.transform.GetChild(i);
                    var sprite = go.gameObject.GetComponent<SpriteRenderer>();
                    sprite.sprite = plants.stages[stageCount];
                }
                break;
            }
        }
    }
    void Deplanter()
    {
        cam.makeShake(shake, shakeTime);
        plants = null;
        planteType = null;
        stageCount = 0;
        col.size = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            var go = gameObject.transform.GetChild(i);
            var sprite = go.gameObject.GetComponent<SpriteRenderer>();
            sprite.sprite = null;
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Deplanter();
        }
    }
    void Update()
    {
        if(plants != null)
        {
            if (stageCount < plants.stages.Count - 1)
            {
                timePassed++;
            }
            if (timePassed > plants.timeToChange)
            {
                timePassed = 0;
                stageCount++;
                for (int i = 0; i < 4; i++)
                {
                    var go = gameObject.transform.GetChild(i);
                    var sprite = go.gameObject.GetComponent<SpriteRenderer>();
                    sprite.sprite = plants.stages[stageCount];
                }
            }
        }
    }

}

