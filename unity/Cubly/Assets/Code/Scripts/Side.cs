using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    public SIDE side;

    public Color ledColor;
    private int id { get; }
    private bool touched { set; get; }
    private Vector3 dir { set; get; }


    private void Update()
    {
        dir = this.transform.up;
    }

    public SIDE getSIDE()
    {
        return side;
    }

    public Vector3 GetV3Up()
    {
        return dir;
    }

}

