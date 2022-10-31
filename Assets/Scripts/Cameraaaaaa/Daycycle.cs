using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycycle : MonoBehaviour
{
    public Light lightDay;
    public Gradient dayColor;
    public bool pauseTime;
    [Space]
    public Light lightNight;
    public Gradient nightColor;
    [Space]
    [Range(0, 100)]
    [Tooltip("In percent %")]
    public float timeOfDay_Percent;
    [Space]
    public float maxDayTime = 60;
    public float timeOfDay = 0;

    public SpriteRenderer bg;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseTime)
        {
            timeOfDay_Percent = (timeOfDay * 100) / maxDayTime;
            timeOfDay += Mathf.Round(Time.deltaTime * 1000) / 1000;
            if (timeOfDay >= maxDayTime)
            {
                timeOfDay = 0;
            }
            UpdateLight();
        }

    }
    public void UpdateLight()
    {
        lightDay.color = dayColor.Evaluate(timeOfDay_Percent/100);
        lightNight.color = nightColor.Evaluate(timeOfDay_Percent / 100);        
        Color yolo = dayColor.Evaluate(timeOfDay_Percent / 100); 
        float yoloh = 0;
        float yolos = 0;
        float yolob = 0;
        Color.RGBToHSV(yolo, out yoloh, out yolos, out yolob);
        //yolob /= 4;
        yolo = Color.HSVToRGB(yoloh, yolos, yolob);
        //yolo.a = .3f;
        bg.color = yolo;
        transform.localEulerAngles = new Vector3(-18, -timeOfDay_Percent * 3.6f + 180, 0f);
    }
    private void OnValidate()
    {
        timeOfDay = (timeOfDay_Percent / 100) * maxDayTime;
        UpdateLight();

    }
}
