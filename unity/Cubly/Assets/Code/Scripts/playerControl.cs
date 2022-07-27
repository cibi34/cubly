using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    private static playerControl _instance;
    public static playerControl Instance
    {
        get { return _instance; }
    }


    public Logic levelLogic;

    private Vector3 anchor;
    private Vector3 axis;

    public bool isMoving = false;
    public bool lockMoving = false;

    private Vector3 offset = new Vector3(0, -0.5f, 0);

    public bool rolledTrigger = false;
    public Queue<Vector3> rollQueue;
    [SerializeField] private float _rollSpeed = 5;


    public List<Side> cube = new List<Side>();

    public UnityEvent OnPlayerHitEvent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        rollQueue = new Queue<Vector3>();

    }


    private void Update()
    {
        processRollQueue();
    }

    public Side getBottom(){
        foreach (Side side in cube){
            if (side.GetV3Up() == Vector3.down){
                return side;
            }
        }
        return null;
    }

    public void processRollQueue()
    {
        if (isMoving) return;
        if (rollQueue.Count > 0){

            Vector3 dir = rollQueue.Dequeue();

            if (lockMoving) return;

            // which kind of collider is there, if i move towards the given direction?
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position + offset + dir, 0.2f);

            if (dir == Vector3.up || dir == Vector3.down)
            {
                MoveCube(dir);
            }else if (hitColliders.Length != 0)
            {
                //Debug.Log("Found something!  " + hitColliders.Length);
                GameObject tile = hitColliders[0].gameObject;
                //Debug.Log(tile);

                levelLogic.HitTile(tile, dir);
            }
             else
            {
                // Out of Grid - Game Over
                MoveCube(dir, true);
            }


        }
    }


    public void MoveCube(Vector3 dir, bool fall = false, Action callback = null)
    {
        if (dir == Vector3.up || dir == Vector3.down)
        {
            anchor = transform.position;
            axis = dir;
        }
        else
        {
            anchor = transform.position + Vector3.Scale((dir + Vector3.down), GetComponent<Renderer>().bounds.size) / 2;
            axis = Vector3.Cross(Vector3.up, dir);
        }

        StartCoroutine(Roll(anchor, axis, fall, callback));
    }


    private IEnumerator Roll(Vector3 anchor, Vector3 axis, bool fall, Action callback)
    {
        isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        isMoving = false;
        rolledTrigger = true;

        if (fall)
        {
            StartCoroutine("Fall");
            yield return null;
        }
        if (callback != null) callback();
    }

    private IEnumerator Fall()
    {
        for (var i = 0; i < 90; i++)
        {
            transform.Translate(Vector3.down * 9 * Time.deltaTime, Space.World);
            // transform.Rotate(Vector3.left, 250 * Time.deltaTime);
            //yield return null;
            yield return new WaitForSeconds(0.01f);

        }

        //yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PreLevel");

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            OnPlayerHitEvent.Invoke();
        }
    }

}
