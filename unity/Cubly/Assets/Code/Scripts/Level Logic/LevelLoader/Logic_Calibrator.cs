using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Logic_Calibrator: Logic
{

    public playerControl cubeController;

    [SerializeField] TextMeshProUGUI t_cd;


    private void Start()
    {
        cubeController.lockMoving = true;
        serialCom.Instance.sendFullColor(6);
    }

    public override void HitTile(GameObject tile, Vector3 dir)
    {
        
        cubeController.MoveCube(dir);        
    }

    public void startCalibration()
    {
        serialCom.Instance.sendReset();
        StartCoroutine(waitForCalib());

    }

    private IEnumerator waitForCalib()
    {
        for(int i = 3; i >= 0 ; i--)
        {
            yield return new WaitForSeconds(1);
            t_cd.text = i.ToString();
            serialCom.Instance.sendVibration();
        }
        SceneManager.LoadScene(GameManager.Instance.currentLevel);
        cubeController.lockMoving = false;
    }




}
