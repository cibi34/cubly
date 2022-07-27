using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Logic_StartScene : Logic
{

    public playerControl cubeController;
    
    public override void HitTile(GameObject tile, Vector3 dir)
    {
        
    }

    public void startGame()
    {
        GameManager.Instance.currentLevel = 2;
        SceneManager.LoadScene("PreLevel");
    }



}
