using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Logic_Lvl7: Logic
{

    public playerControl cubeController;

    public override void HitTile(GameObject tile, Vector3 dir)
    {
        if (tile.GetComponent<Tile>().isTarget)
        {
            Debug.Log("Target Reached");

            // Next Level
            GameManager.Instance.currentLevel = 2;
            cubeController.MoveCube(dir);
            SceneManager.LoadScene(0);


        }
        else
        {
            //Move
            cubeController.MoveCube(dir);
        }
    }


    public void reloadLvl()
    {
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("PreLevel");
    }




}
