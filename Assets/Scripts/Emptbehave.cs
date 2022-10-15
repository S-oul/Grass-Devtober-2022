using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emptbehave : MonoBehaviour
{
    Grider grider;
    Outline lines;

    Oncam cam;

    public float shakeTime;
    public float shake;

    public Color BaseColor = Color.white;
    public Color OverColor = Color.red;
    public Color ClickColor = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Oncam>();

        grider = transform.parent.GetComponentInParent<Grider>();
        lines = GetComponent<Outline>();
    }
    void OnMouseOver()
    {
        transform.localScale = new Vector3(.5f,.5f,.5f);
        if (Input.GetMouseButton(0))
        {
            lines.OutlineColor = ClickColor;
        }else if (Input.GetMouseButtonUp(0))
        {
            //print((int)(transform.position.x - 1.5f) + " " + (int)(transform.position.y-1.5f));
            grider.empCubelist.Remove(gameObject.transform);
            Destroy(gameObject);    
            cam.makeShake(shake, shakeTime);
            grider.PoseGrass((int)((transform.parent.localPosition.x) + transform.localPosition.x + grider.center.x), (int)((transform.parent.localPosition.z) +transform.localPosition.z + grider.center.y), false);
        }
        else
        {
            lines.OutlineColor = OverColor;
        }
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(.4f, .4f, .4f);
        lines.OutlineColor = BaseColor;
    }
}
