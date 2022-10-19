using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emptbehave : MonoBehaviour
{
    Grider grider;
    Outline lines;

    public GameObject grassBlock;
    public List<GameObject> toActive;

    Oncam cam;

    public float shakeTime;
    public float shake;

    public Color BaseColor = Color.white;
    public Color OverColor = Color.red;
    public Color ClickColor = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Ngo in toActive)
        {
            Ngo.SetActive(false);

        }
        cam = FindObjectOfType<Oncam>();

        grider = transform.parent.GetComponentInParent<Grider>();
        lines = GetComponent<Outline>();
    }
    void OnMouseOver()
    {
        transform.localScale = new Vector3(.6f,.6f,.6f);
        if (Input.GetMouseButton(0))
        {
            lines.OutlineColor = ClickColor;
        }else if (Input.GetMouseButtonUp(0))
        {
            //print((int)(transform.position.x - 1.5f) + " " + (int)(transform.position.y-1.5f));
            //grider.empCubelist.Remove(gameObject.transform);
            //grider.PoseGrass((int)((transform.parent.localPosition.x) + transform.localPosition.x + grider.center.x), (int)((transform.parent.localPosition.z) +transform.localPosition.z + grider.center.y), false);
            Pose();
            Destroy(gameObject);    
            cam.makeShake(shake, shakeTime);
        }
        else
        {
            lines.OutlineColor = OverColor;
        }
    }
    public void Pose()
    {
        var go = Instantiate(grassBlock);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        Vector2 posname = new Vector2(Mathf.RoundToInt(transform.localPosition.x /1.5f), Mathf.RoundToInt(transform.localPosition.z /1.5f));
        go.name = "GrassBlock " + posname.x + " " + posname.y;
        print("aaaaaaa");
        go.transform.parent = transform.parent;

        foreach (GameObject Ngo in toActive)
        {
            if (Ngo != null)
            {
                Ngo.SetActive(true);
            }
        }
        
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(.5f, .5f, .5f);
        lines.OutlineColor = BaseColor;
    }
}
