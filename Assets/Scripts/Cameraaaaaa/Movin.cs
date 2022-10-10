using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movin : MonoBehaviour
{
    public GameObject terrainL;
    public GameObject terrainR;
    public GameObject terrainSelf;
    private GameObject elseuh;

    public bool isGoingL = false;
    public bool isGoingR = false;
    public AnimationCurve posCurve;
    public float speed;
    float CurveTime;

    public Vector3 dir;
    private List<Vector3> direction = new List<Vector3>() 
    { 
        new Vector3(1, 0, -1), // GAUCHE 0
        new Vector3(-1, 0, 1) // DROITE 1
    };

    public void GoToLeft()
    {
        isGoingL = true;
        dir = direction[0];
    }
    public void GoToRight()
    {
        isGoingR = true;
        dir = direction[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingL)
        {
            
            transform.position += dir * Time.deltaTime * speed * posCurve.Evaluate(1/Vector2.Distance(transform.position, terrainL.transform.position));
            CurveTime += 0.01f;
            print(1 / Vector2.Distance(transform.position, terrainL.transform.position) + " " + posCurve.Evaluate(1 / Vector2.Distance(transform.position, terrainL.transform.position)));
            if (Vector2.Distance(transform.position, terrainL.transform.position) - 1 <= .01f)
            {
                transform.position = new Vector3(terrainL.transform.position.x, -1, terrainL.transform.position.z);
                isGoingL = false;
                CurveTime = 0;
                elseuh = terrainL;
                terrainR = terrainSelf;
                terrainSelf = elseuh;
            }
        }
        if (isGoingR)
        {
            transform.position += dir * Time.deltaTime * speed ;
            CurveTime += 0.01f;
            if (Vector2.Distance(transform.position, terrainR.transform.position) - 1 <= .01f)
            {
                transform.position = new Vector3(terrainR.transform.position.x, -1, terrainR.transform.position.z); 
                isGoingR = false;
                CurveTime = 0;
                elseuh = terrainR;
                terrainL = terrainSelf;
                terrainSelf = elseuh;

            }
        }

    }
}
