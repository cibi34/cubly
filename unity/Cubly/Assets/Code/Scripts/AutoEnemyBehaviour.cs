using System.Collections;
using UnityEngine;

public class AutoEnemyBehaviour : MonoBehaviour
{
    public int speed;
    private bool moving;

    void Start()
    {
       playerControl.Instance.OnPlayerHitEvent.AddListener(StopEnemies);
        moving = true;
        EnemyMovement();
    }

    private void StopEnemies()
    {
        moving = false;
    }

    private void EnemyMovement()
    {
        if (!moving) return; 
        int randomDir = Random.Range(1, 5);

        Vector3 dir = new Vector3(0, 0, 0); ;
        if (randomDir == 1) dir = new Vector3(1, 0, 0);
        else if (randomDir == 2) dir = new Vector3(-1, 0, 0);
        else if (randomDir == 3) dir = new Vector3(0, 0, 1);
        else if (randomDir == 4) dir = new Vector3(0, -0, -1);


        Vector3 groundPosition = gameObject.transform.position - new Vector3(0,0.5f,0);
        Collider[] hitColliders = Physics.OverlapSphere(groundPosition + dir, 0.2f);

        if (hitColliders.Length != 0)
        {
            bool moveEnemy = true;

            //foreach (Collider hitCollider in hitColliders)
            //{
            //    if (hitCollider.gameObject.CompareTag("Enemy") || hitCollider.gameObject.GetComponent<Tile>().isBomb)
            //    {
            //        moveEnemy = false;
             //   }
            //}
            if (moveEnemy) StartCoroutine(SmoothMovement(dir));
            else EnemyMovement();
        }
        else
        {
            EnemyMovement();
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
