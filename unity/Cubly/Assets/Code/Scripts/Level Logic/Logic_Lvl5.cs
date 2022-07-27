using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class Logic_Lvl5 : Logic
{

    public playerControl cubeController;

    [SerializeField] sideDetector sD;
    public GridManager gridManager;
    [SerializeField] TextMeshProUGUI t_cd;

    public Material tileMat;
    public Material pathMat;

    [SerializeField] GameObject targetTile;
    [SerializeField] GameObject startTile;


    private GameObject currentTile;


    public override void HitTile(GameObject tile, Vector3 dir)
    {
        currentTile = tile;

        if (tile.GetComponent<Tile>().isHole)
        {
            Debug.Log("FALL!");
            cubeController.MoveCube(dir, true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (tile.GetComponent<Tile>().isPath)
        {
            Debug.Log("GOOD! Coorect Path");
            cubeController.MoveCube(dir, false, HandlePath);

        }
        else if (tile.GetComponent<Tile>().isTarget)
        {
            Debug.Log("Target Reached!");

            // Next Level
            cubeController.MoveCube(dir, false, GameManager.Instance.GameFinished);

        }
        else if(!tile.GetComponent<Tile>().isTarget && !tile.GetComponent<Tile>().isPath)
        {
            //Wrong Path!
            Debug.Log("Wrong Path! Try Again.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    private void HandlePath()
    {
        Material material = Resources.Load("gridbox_orange", typeof(Material)) as Material;
        currentTile.GetComponent<Renderer>().material = material;
        //serialCom.Instance.sendFullColor((int)SIDE.RED);
        //serialCom.Instance.sendVibration();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountDown()
    {

        for (int i = 2; i >= 0; i--)
        {
            serialCom.Instance.sendVibration();
            yield return new WaitForSeconds(1);
            t_cd.text = i.ToString();
        }
        serialCom.Instance.sendVibration();
        t_cd.text = "";

        serialCom.Instance.sendFullColor((int)SIDE.WHITE);
        cubeController.lockMoving = false;

        gridManager.SetTileColor(tileMat);

        targetTile.GetComponent<Renderer>().material = Resources.Load("gridbox_green", typeof(Material)) as Material;

        startTile.GetComponent<Renderer>().material = Resources.Load("gridbox_white", typeof(Material)) as Material;

    }
}
