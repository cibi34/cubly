using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player;

    public int currentLevel;

    private static GameManager _instance;

    public static GameManager Instance
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


    // Start is called before the first frame update
    void Start()
    {
        //InstatiatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameFinished()
    {
        Debug.Log("TARGET REACHED");
        currentLevel++;
        SceneManager.LoadScene("PreLevel");
    }

    public void ReloadScene()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
