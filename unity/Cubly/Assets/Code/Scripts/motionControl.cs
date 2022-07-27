using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionControl : MonoBehaviour
{

    [SerializeField] private playerControl pc;
    [SerializeField] private serialCom sc;

    private float speedFactor = 15f;

    private Quaternion rotOffset = Quaternion.identity;
    private Quaternion qt = new Quaternion();


    private static motionControl _instance;

    public static motionControl Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

    }



    void Start(){
        StartCoroutine(InitCalibration());
    }

    void Update(){
        qt = serialCom.Instance.getCubeQuat();
        if (!qt.IsValid()) return;
        RotateAbsolute();
    }

    private void RotateAbsolute(){

        this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, qt * Quaternion.Inverse(rotOffset), Time.deltaTime * speedFactor);
    }

    public void resetOrientation()
    {

        sc.sendReset();
        this.transform.localRotation = Quaternion.identity; 
        pc.isMoving = true;
        rotOffset = qt * Quaternion.Inverse(Quaternion.identity);
        pc.transform.rotation = Quaternion.identity;
        StartCoroutine(WaitForCalibration());
    }


    IEnumerator InitCalibration()
    {
        yield return new WaitForSeconds(0.5f);
        pc.isMoving = true;
        rotOffset = qt * Quaternion.Inverse(Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        pc.isMoving = false;
    }

    IEnumerator WaitForCalibration()
    {
        yield return new WaitForSeconds(4);
        pc.isMoving = false;
    }



}
