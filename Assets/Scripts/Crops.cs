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
    GameObject dropped;

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
                dropped = gm.youlldrop;
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
        Destroy(go.GetComponent<RectTransform>());
        Destroy(go.GetComponent<CanvasRenderer>());
        Destroy(go.GetComponent<Button>());
        Destroy(go.GetComponent<inventorySlots>());
        var sun = go.transform.GetChild(0).gameObject.AddComponent<SpriteRenderer>(); 
        sun.sprite = go.transform.GetChild(0).GetComponent<Image>().sprite;
        var water = go.transform.GetChild(1).gameObject.AddComponent<SpriteRenderer>();
        water.sprite = go.transform.GetChild(1).GetComponent<Image>().sprite;
        var drop = go.transform.GetChild(2).gameObject.AddComponent<SpriteRenderer>();
        drop.sprite = go.transform.GetChild(2).GetComponent<Image>().sprite;
        var soil = go.transform.GetChild(3).gameObject.AddComponent<SpriteRenderer>();
        soil.sprite = go.transform.GetChild(3).GetComponent<Image>().sprite;
        var mut = go.transform.GetChild(4).gameObject.AddComponent<SpriteRenderer>();
        mut.sprite = go.transform.GetChild(4).GetComponent<Image>().sprite;
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
            sprite.color = Color.HSVToRGB(0,0,.80f);
        }
        if (Input.GetMouseButton(0))
        {

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Deplanter();
            dropme(dropped);
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

