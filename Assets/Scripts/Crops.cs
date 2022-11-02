using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Crops : MonoBehaviour
{
    public string planteType = null;
    PlantMaster pm;
    public PlantMaster.Plant plants;
    GameMaster gm;
    Daycycle dayCycle;

    Color dropSunCol;
    Color dropWaterCol;
    Color dropSoilCol;
    Color dropDropCol;
    Color dropMutCol;

    public float timePassed;
    public int stageCount = 0;
    
    Oncam cam;
    public float shakeTime;
    public float shake;

    BoxCollider col;
    bool planted;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Oncam>();
        gm = FindObjectOfType<GameMaster>();
        dayCycle = FindObjectOfType<Daycycle>();
        pm = FindObjectOfType<PlantMaster>();
        col = GetComponent<BoxCollider>();
    }
    public void Planter(PlantMaster.Plant plat)
    {
        //print("oui, taace");
        if (!planted && gm.cando)
        {
            planted = true;
            col.size = Vector3.one;
            cam.makeShake(shake, shakeTime);
            if (plat != null)
            {
                plants = plat;
            }else
            {
                foreach (PlantMaster.Plant plant in pm.list)
                {
                    if (plant.type == planteType)
                    {
                        plants = plant;
                        break;    
                    }
                }                    
            }
            print(plants.type);
            /*dropSunCol = gm.youllDrop.Suncol;
            dropDropCol = gm.youllDrop.Dropcol;
            dropMutCol = gm.youllDrop.Mutcol;
            dropSoilCol = gm.youllDrop.Soilcol;
            dropWaterCol = gm.youllDrop.Watercol;*/

            //int z = 0;
            for (int i = 0; i < 4; i++)
            {
                var go = gameObject.transform.GetChild(i);
                var sprite = go.gameObject.GetComponent<SpriteRenderer>();
                sprite.sprite = plants.stages[stageCount];
            }
        }
    }
    
    void dropme(GameObject dropp)
    {
        var go = Instantiate(dropp);
        go.transform.parent = transform.parent.parent;
        //go.AddComponent<Transform>();
        var gorb = go.AddComponent<Rigidbody>();
        float xplus = (float)Random.Range(-200, 200) / 100;
        float yplus = (float)Random.Range(-200, 200) / 100;
        gorb.AddForce(new Vector3(xplus, 3 , yplus), ForceMode.Impulse);
        print(xplus + " " + yplus);

        go.GetComponent<Welp>().type = plants.type;
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        go.transform.GetChild(0).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Sun");
        go.transform.GetChild(1).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Water");
        go.transform.GetChild(2).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Drop");
        go.transform.GetChild(3).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Soil");
        go.transform.GetChild(4).gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Seeds/Mutation");

        go.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = plants.Suncol     ;
        go.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = plants.watercol   ;
        go.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = plants.dropcol    ;
        go.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = plants.soilcol    ;
        go.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = plants.mutationcol;
        //Debug.LogError("caca");
    }
    public void Deplanter()
    {
        if (gm.cando)
        {
            planted = false;
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

            //MUTATIONBITCH
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
        else if (Input.GetMouseButtonUp(0) && gm.cando)
        {
            if (stageCount >= plants.stages.Count - 1)
            {
                /*if(Random.Range(0,1000)/1000 <= plants.mutationChance)
                {

                }*/
                dropme(Resources.Load<GameObject>("Seeds/Seed drop"));
                dropme(Resources.Load<GameObject>("Seeds/Seed drop"));
                gm.AddMoney((int)plants.sellPrice);
            }
            dropme(Resources.Load<GameObject>("Seeds/Seed drop"));
            Deplanter();
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
                //print(Mathf.Abs(old - timePassed));
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

