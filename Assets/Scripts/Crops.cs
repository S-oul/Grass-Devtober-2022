using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Crops : MonoBehaviour
{
    public string planteType = null;
    PlantMaster pm;
    PlantMaster.Plant plants = null;
    GameMaster gm;
    Daycycle dayCycle;
    GameMaster.YoullDrop dropped;

    public float timePassed;
    public int stageCount = 0;
    
    Oncam cam;
    public float shakeTime;
    public float shake;

    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Oncam>();
        gm = FindObjectOfType<GameMaster>();
        dayCycle = FindObjectOfType<Daycycle>();
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
                dropped = gm.youllDrop;
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
    void dropme(GameObject dropp)
    {
        var go = Instantiate(dropp);
        go.AddComponent<Transform>();

        go.transform.GetChild(0).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Sun");
        go.transform.GetChild(1).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Water");
        go.transform.GetChild(2).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Drop");
        go.transform.GetChild(3).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Soil");
        go.transform.GetChild(4).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Mutation");

        go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = dropped.Suncol;
        go.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = dropped.Watercol;
        go.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = dropped.Dropcol;
        go.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = dropped.Soilcol;
        go.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = dropped.Mutcol;

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
        for (int i = 0; i < 4; i++)
        {
            var go = gameObject.transform.GetChild(i);
            var sprite = go.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = Color.HSVToRGB(0,0,.90f);
        }
        if (Input.GetMouseButton(0))
        {

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Deplanter();
            dropme(Resources.Load<GameObject>("Seeds/Wheat"));
        }
    }
    private void OnMouseExit()
    {
        for (int i = 0; i < 4; i++)
        {
            var go = gameObject.transform.GetChild(i);
            var sprite = go.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = Color.HSVToRGB(0, 0, 1);
        }
    }
    void Update()
    {
        if(plants != null)
        {
            if (stageCount < plants.stages.Count - 1)
            {
                var old = timePassed;
                timePassed += plants.growthspeed * plants.growthOnLight.Evaluate(dayCycle.timeOfDay_Percent/100) *.1f;
                print(Mathf.Abs(old - timePassed));
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

