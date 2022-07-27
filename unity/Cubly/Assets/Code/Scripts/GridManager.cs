using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gridTilePrefab;
    [SerializeField]
    private int gridSizeX = 10;
    [SerializeField]
    private int gridSizeY = 5;


    public GameObject[,] grid;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGridFromChildren();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject GetTile(int x, int y)
    {
        return grid[x, y];
    }

    void PrintGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeY; z++)
            {
                print(grid[x, z]);
            }
        }
    }

    public GameObject[,] getGrid()
    {
        return grid;
    }

    public void GenerateTiles()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeY; z++)
            {
                GameObject tile = Instantiate(gridTilePrefab, new Vector3(x, 0, z), Quaternion.identity, gameObject.transform);
                tile.transform.eulerAngles = new Vector3(0, 180, 0);
                tile.name = "Tile_" + x + "_" + z; 
            }
        }
    }

    public void GenerateGridFromChildren()
    {
        grid = new GameObject[gridSizeX, gridSizeY];

        if (transform.childCount == 0) return;


        List<GameObject> tileArray = new List<GameObject>();


        foreach (Transform child in transform)
        {
            tileArray.Add(child.gameObject);
        }


        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                grid[x, y] = tileArray[x * gridSizeY + y];

            }
        }
    }

    public int getGridSizeX()
    {
        return gridSizeX;
    }

    public int getGridSizeY()
    {
        return gridSizeY;
    }
    
    public void SetTileColor(Material mat)
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                grid[x, y].GetComponent<Renderer>().material = mat;

            }
        }
    }

}
