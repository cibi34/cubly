using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDetector : MonoBehaviour
{
    private float range = 1;
    private Vector3 vTop = Vector3.down;

    public SIDE getTop(){


        Ray topRay = new Ray(transform.position, transform.TransformDirection(vTop * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(vTop * range), Color.cyan);

        if (Physics.Raycast(topRay, out RaycastHit hitTop, range))
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
