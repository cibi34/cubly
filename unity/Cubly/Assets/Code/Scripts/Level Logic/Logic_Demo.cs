using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Logic_Demo : Logic
{
    public playerControl cubeController;

    [SerializeField] GridManager grid;
    [SerializeField] sideDetector sD;



    private GameObject currentTile;
    private SIDE currentTileColor;

    public override void HitTile(GameObject tile, Vector3 dir)
    {
        currentTile = tile;
        if (tile.GetComponent<Tile>().isHole)
        {
            Debug.Log("Hit Hole");
            cubeController.MoveCube(dir, true);
        }
        else if (tile.GetComponent<Tile>().isTarget)
        {
            Debug.Log("Target Reached");

            // Next Level
            cubeController.MoveCube(dir, false, LoadNewScene);
        }
        //else 
        //if (tile.GetComponent<Tile>().side == SIDE.WHITE)
        //{
        //    cubeController.MoveCube(dir, false, CheckTileColor);
        //}
        else
        {
            //Move
            currentTileColor = tile.GetComponent<Tile>().side;
            cubeController.MoveCube(dir, false, ColorCube );
        }

        

    }

    // Start is called before the first frame update
    void Start()
    {
        grid.GenerateGridFromChildren();

        int gX = grid.getGridSizeX();
        int gY = grid.getGridSizeY();

        for (int i = 0; i < gX; i++)
        {
            for (int j = 0; j < gY; j++)
            {
                GameObject go = grid.GetTile(i, j);
            }
        }
        serialCom.Instance.sendFullColor(6);
    }

    private void ColorCube()
    {

        if(currentTileColor != SIDE.UNDEF) serialCom.Instance.sendFullColor((int)currentTileColor);


    }
    private void CheckTileColor()
    {
     

        if (cubeController.getBottom().side == SIDE.WHITE)
        {
            //Material material = Resources.Load("gridbox_darkgrey", typeof(Material)) as Material;
            //print("White on white");
            //currentTile.GetComponent<Renderer>().material = material;

        }
    }

    private void LoadNewScene()
    {
        print("next lvl");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        serialCom.Instance.sendFullColor(6);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeController.rolledTrigger)
        {
            //print(cubeController.getBottom().side.ToString());
            cubeController.rolledTrigger = false;
        }

    }

}


