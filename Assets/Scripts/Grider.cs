using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grider : MonoBehaviour
{
    public Vector2 size = new Vector2(3,3);
    public Vector2 where = new Vector2(1, 1);

    public Oncam cam;

    Cells[,] grid = new Cells[0,0];
    public GameObject emptyCube;
    public GameObject grassBlock;
    List<GameObject> grassList = new List<GameObject>();
    void Start()
    {
        cam = FindObjectOfType<Oncam>();

        grid = new Cells[(int)size.x, (int)size.y];
        CheckGrid();
        PoseGrass((int)where.x, (int)where.y);
        DrawExtCube();
    }
    public void CheckGrid()
    {
        Cells cells = new Cells();

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                if (grid[x, y] == null)
                {
                    cells.coords = new int[x,y];
                    cells.isEmp = true;
                    grid[x, y] = cells;
                }
            }
        }
    }
    public void PoseGrass(int x, int y)
    {
        var go = Instantiate(grassBlock);
        go.name = "Grass " + x + "," + y;
        go.transform.parent = gameObject.transform;
        go.transform.localPosition = new Vector3((x) * 1.5f, -1, (y) * 1.5f);
        go.transform.localEulerAngles = Vector3.zero;
        grassList.Add(go);

        Cells cells = new Cells();
        cells.coords = new int[x, y];
        cells.type = "Grass";
        cells.go = go;
        cells.solid = true;
        cells.isEmp = false;
        grid[(int)where.x, (int)where.y] = cells;


    }
    public void DrawExtCube()
    {
        if (size.x == 1)
        {

            var go1 = Instantiate(emptyCube);
            go1.transform.parent = grid[(int)where.x, (int)where.y].go.transform;
            go1.transform.localPosition = new Vector3(1f, 0, 0);

            var go2 = Instantiate(emptyCube);
            go2.transform.parent = grid[(int)where.x, (int)where.y].go.transform;
            go2.transform.localPosition = new Vector3(-1f, 0, 0);
            return;
        }
        if(size.y == 1)
        {
            var go1 = Instantiate(emptyCube);
            go1.transform.parent = grid[(int)where.x, (int)where.y].go.transform;
            go1.transform.localPosition = new Vector3(0, 0, -1);

            var go2 = Instantiate(emptyCube);
            go2.transform.parent = grid[(int)where.x, (int)where.y].go.transform;
            go2.transform.localPosition = new Vector3(0, 0, 1);
            return;
        }
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                if (grid[x, y].type == "Grass")
                {
                    for(int i = -1; i < 2; i++)
                    {
                        for(int j = -1; j < 2; j++)
                        {
                            if ((i == -1 || i == 1) && (j == -1 || j == 1))
                            {

                            }
                            else
                            {
                            var go1 = Instantiate(emptyCube);
                            go1.transform.parent = grid[x, y].go.transform;
                            go1.transform.localPosition = new Vector3(i, 0, j);
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
public class Cells
{
    public int[,] coords;
    public string type;
    public GameObject go;
    public bool solid = false;
    public bool isEmp = false;
}
