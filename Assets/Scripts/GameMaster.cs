using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public string type = "Wheat";
    public YoullDrop youllDrop = new YoullDrop();
    public class YoullDrop
    {
        public Color Suncol;
        public Color Watercol;
        public Color Dropcol;
        public Color Soilcol;
        public Color Mutcol;
    }
}
