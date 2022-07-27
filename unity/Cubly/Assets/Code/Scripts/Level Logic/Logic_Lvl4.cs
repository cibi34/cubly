using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class Logic_Lvl4 : Logic
{

    public playerControl cubeController;

    [SerializeField] sideDetector sD;

    private GameObject currentTile;


    public override void HitTile(GameObject tile, Vector3 dir)
    {
        currentTile = tile;

        if (tile.GetComponent<Tile>().isHole)
        {
            Debug.Log("FALL!");
            cubeController.MoveCube(dir, true);
        }
        else if (tile.GetComponent<Tile>().isBomb)
        {
            Debug.Log("BOMB!");
            cubeController.MoveCube(dir, false, HandleBomb);

        }
        else if (tile.GetComponent<Tile>().isTarget)
        {
            Debug.Log("Target Reached!");

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
        StartCoroutine(CountDown());

    }

    private void HandleBomb()
    {
        print("BOOOOOOOOOOOM!");
        Material material = Resources.Load("gridbox_orange", typeof(Material)) as Material;
        currentTile.GetComponent<Renderer>().material = material;
        serialCom.Instance.sendFullColor((int)SIDE.RED);
        serialCom.Instance.sendVibration();
        cubeController.OnPlayerHitEvent.Invoke();
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("PreLevel");
    }
    IEnumerator CountDown()
    {
        //serialCom.Instance.sendReset();
        yield return new WaitForSeconds(1);

        //for (int i = 2; i >= 0; i--)
        //{
        //    serialCom.Instance.sendVibration();
        //    yield return new WaitForSeconds(1);
        //    t_cd.text = i.ToString();
        //}
        //serialCom.Instance.sendVibration();
        //t_cd.text = "";

        serialCom.Instance.sendFullColor((int)SIDE.WHITE);
        cubeController.lockMoving = false;
    }
}
