using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic_Lvl2 : Logic
{


    public playerControl cubeController;

    [SerializeField] GridManager grid;
    [SerializeField] sideDetector sD;


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
}


