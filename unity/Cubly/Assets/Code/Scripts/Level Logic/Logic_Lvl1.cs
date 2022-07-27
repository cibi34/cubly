using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Logic_Lvl1 : Logic
{

    public playerControl cubeController;


    public override void HitTile(GameObject tile, Vector3 dir)
    {
        if (tile.GetComponent<Tile>().isHole)
        {
            Debug.Log("Hit Hole");
            cubeController.MoveCube(dir, true);
        }
        else if (tile.GetComponent<Tile>().isTarget)
        {
            Debug.Log("Target Reached");
            // Next Level
            cubeController.MoveCube(dir, false, GameManager.Instance.GameFinished);

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
        serialCom.Instance.sendFullColor(6);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
