using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class Logic_Lvl3 : Logic
{

    public playerControl cubeController;

    [SerializeField] GridManager grid;
    [SerializeField] sideDetector sD;
    [SerializeField] TextMeshProUGUI txtCounter;

    private GameObject currentTile;


    private  SIDE[] sideCounter = new SIDE[6];
    private int counter = 0;

    public override void HitTile(GameObject tile, Vector3 dir)
    {
        currentTile = tile;
        if (tile.GetComponent<Tile>().isHole)
        {
            Debug.Log("Hit Hole");
            cubeController.MoveCube(dir, true);
        }
        else if (tile.GetComponent<Tile>().isTarget && counter == 6)
        {

                Debug.Log("Target Reached");

                // Next Level
                cubeController.MoveCube(dir, false, GameManager.Instance.GameFinished);
     
  
        }
        else if (tile.GetComponent<Tile>().side == SIDE.WHITE)
        {
            cubeController.MoveCube(dir, false, CheckTileColor);
        }
        else
        {
            //Move
            cubeController.MoveCube(dir);
        }
            
        
    }

    // Start is called before the first frame update
    void Start()
    {
        serialCom.Instance.sendFullColor((int)SIDE.UNDEF);
        txtCounter.text = counter.ToString() +"/6";

    }

    private void CheckTileColor()
    {

        SIDE btm = cubeController.getBottom().side;
        print((int)btm);
        if (sideCounter[(int)btm] != SIDE.WHITE)
        {

            serialCom.Instance.sendVibration();
            sideCounter[(int)btm] = SIDE.WHITE;
            Material material = Resources.Load("gridbox_darkgrey", typeof(Material)) as Material;
            currentTile.GetComponent<Renderer>().material = material;
            counter++;
            txtCounter.text = counter.ToString() + "/6";
            serialCom.Instance.sendColorSide((int)btm, (int)SIDE.WHITE);
        }



        //if (btm == SIDE.WHITE)
        //{
        //    Material material = Resources.Load("gridbox_darkgrey", typeof(Material)) as Material;
        //    print("White on white");
        //    currentTile.GetComponent<Renderer>().material = material;

        //}
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
