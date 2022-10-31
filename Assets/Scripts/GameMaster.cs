using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public string type = "Wheat";
    public YoullDrop youllDrop = new YoullDrop();

    public int money = 600;
    public TextMeshProUGUI moneytext;
    public bool cando;
    public ShopDropdown sdd;

    private void Start()
    {
        sdd = FindObjectOfType<ShopDropdown>();
    }
    public void Update()
    {
        cando = sdd.dobidown;
        string convert = "" + money;
        moneytext.text = convert;
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetMoney(2000);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetMoney(200);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetMoney(200);
        }
    }
    public class YoullDrop
    {
        public Color Suncol;
        public Color Watercol;
        public Color Dropcol;
        public Color Soilcol;
        public Color Mutcol;
    }

    public void SetMoney(int amount)
    {
        money = amount;
    }
    public void AddMoney(int amount)
    {
        money += amount;
    }
    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
}
