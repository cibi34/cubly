using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int speed;
    private bool moving;

    private Vector3 currentDirection;

    void Start()
    {
        playerControl.Instance.OnPlayerHitEvent.AddListener(StopEnemies);
        moving = true;
        currentDirection = Vector3.forward;
        EnemyMovement();
    }

    private void StopEnemies()
    {
        moving = false;
    }


    private bool ContainsEnemyPath(Vector3 dir)
    {
        bool containsEnemyPath = false;

        Vector3 groundPosition = gameObject.transform.position - new Vector3(0, 0.5f, 0);
        Collider[] hitColliders = Physics.OverlapSphere(groundPosition + dir, 0.2f);

        if (hitColliders.Length > 0)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                //print(hitCollider.gameObject);
                if (hitCollider.gameObject.GetComponent<Tile>() != null)
                {
                    if (hitCollider.gameObject.GetComponent<Tile>().isEnemyPath)
                    {
                        return true;
                    }
                }
            }
        }
        return containsEnemyPath;
    }


    private void EnemyMovement()
    {
        if (!moving) return;


        if (ContainsEnemyPath(currentDirection))
        {
            StartCoroutine(SmoothMovement(currentDirection));
        } else
        {
            if (currentDirection == Vector3.forward) currentDirection = Vector3.back;
            else currentDirection = Vector3.forward;
            StartCoroutine(SmoothMovement(currentDirection));
        }
    }

    private IEnumerator SmoothMovement(Vector3 dir)
    {
        Vector3 target = transform.position + (dir);

        while (transform.position != target)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            yield return null;
        }
        EnemyMovement();
    }
}
