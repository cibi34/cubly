using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Logic_Lvl6 : Logic
{

    public playerControl cubeController;

    public override void HitTile(GameObject tile, Vector3 dir)
    {
        if (tile.GetComponent<Tile>().isTarget)
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



    public void reloadLvl()
    {
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("PreLevel");
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }



}
