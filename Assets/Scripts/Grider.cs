using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grider : MonoBehaviour
{
    public Vector2 size = new Vector2(3,3);
    public Vector2 where = new Vector2(1, 1);
    public Vector2Int center = new Vector2Int(1, 1);


    public Oncam cam;

    Cells[,] grid = new Cells[0,0];
    public GameObject emptyCube;
    public GameObject fusionBlock;
    public GameObject grassBlock;
    List<GameObject> grassList = new List<GameObject>();
    public bool isFusion;
    [HideInInspector]
    public List<Transform> empCubelist = new List<Transform>();
    void Start()
    {
        cam = FindObjectOfType<Oncam>();

        grid = new Cells[(int)size.x, (int)size.y];
        CheckGrid(false);
        PoseGrass(center.x, center.y, isFusion);
    }
    public void CheckGrid(bool check)
    {
        Cells cells = new Cells();
        if (!check)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    //print(x + " " + y);
                    if (grid[x, y] == null)
                    {
                        cells.coords = new Vector2(x,y) ;
                        cells.isEmp = true;
                        grid[x, y] = cells;
                    }
                }
            }
        }
/*        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                //print(grid[x, y].coords);
            }
        }*/
    }
    public void PoseGrass(int x, int y, bool isFusi)
    {
        var go = gameObject;
        if (!isFusi)
        {
            go = Instantiate(grassBlock);
            go.name = "Grass " + x + "," + y;

        }
        else
        {
            go = Instantiate(fusionBlock);
            go.name = "Fusion Grass ";

        }
        foreach (GameObject gol in grassList)
        {
            if (gol.name == go.name)
            {
                Destroy(go);
                return;
            }
        }
        go.transform.parent = gameObject.transform;
        go.transform.localPosition = new Vector3((x - center.x) * 1.5f, -1, (y - center.y) * 1.5f);
        go.transform.localEulerAngles = Vector3.zero;
        grassList.Add(go);
        Cells cells = new Cells();
        cells.coords = new Vector2(x, y);
        print(x +" "+ y);
        cells.type = "Grass";
        cells.go = go;
        cells.solid = true;
        cells.isEmp = false;
        grid[x, y] = cells;

        DrawExtCube();
    }
    public void DrawExtCube()
    {
        foreach (Cells cell in grid)
        {
            if (cell.type == "Grass" && cell.go.transform.childCount == 1)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((i == 0 || j == 0) /*&& (cell.coords.x < size.x -center.x || cell.coords.x > 1) && (cell.coords.y < size.y -center.y || cell.coords.y > 1)*/)
                        {
                            if (i==0 && j == 0)
                            {
                            }
                            else /*if (grid[i + (int)cell.coords.x, j + (int)cell.coords.x] != null)*/
                            {
                                //print(cell.go.transform);
                                var go1 = Instantiate(emptyCube);
                                go1.name = "OutCube " + i + " " + j; 
                                go1.transform.parent = cell.go.transform;
                                go1.transform.localPosition = new Vector3(i, 0, j);
                                if ((size.x+transform.position.x) > go1.transform.position.x && go1.transform.position.x > (-size.x + transform.position.x) && go1.transform.position.z > (-size.y + transform.position.z) && (size.y + transform.position.z) > go1.transform.position.z)
                                {
                                    if (empCubelist.Count == 0)
                                    {
                                        //print("HEYHEY");
                                        empCubelist.Add(go1.transform);
                                    }
                                    else
                                    {
                                        foreach (Transform pos in empCubelist.ToArray())
                                        {
                                            if (go1.transform.position.x == pos.position.x && go1.transform.position.z == pos.position.z)
                                            {
                                                print("DESTROY");
                                                Destroy(go1); //destroy pos ?
                                                break;
                                            }
                                            else
                                            {
                                                print("added");
                                                empCubelist.Add(go1.transform);
                                                break;
                                            }
                                        }
                                    }
                                }else
                                {
                                    print("DESTROY OOB");
                                    Destroy(go1);
                                }
                            }
                        }
                    }  
                }
            }
        }
    }
    public void DrawOneCube(int x, int y)
    {
        var go1 = Instantiate(emptyCube);
        go1.transform.position = new Vector3(x, -1, y);
    }
}
public class Cells
{
    public Vector2 coords;
    public string type;
    public GameObject go;
    public bool solid = false;
    public bool isEmp = false;
}
