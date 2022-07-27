using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fwdDetector : MonoBehaviour
{
    private float range = 1;
    private Vector3 vFwd = Vector3.forward;

    public SIDE getFront(){

        Ray fwdRay = new Ray(transform.position, transform.TransformDirection(vFwd * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(vFwd * range), Color.magenta);

        if (Physics.Raycast(fwdRay, out RaycastHit hitTop, range))
        {
            switch (hitTop.collider.tag)
            {

                case "red":
                    return SIDE.RED;

                case "green":
                    return SIDE.GREEN;

                case "blue":
                    return SIDE.BLUE;

                case "yellow":
                    return SIDE.YELLOW;

                case "white":
                    return SIDE.WHITE;

                case "purple":
                    return SIDE.PURPLE;

                default:
                    return SIDE.UNDEF;
            }
        }
        return SIDE.UNDEF;
    }
}
