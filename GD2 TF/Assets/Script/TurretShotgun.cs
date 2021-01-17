using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShotgun : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyGrounds = GameObject.FindGameObjectsWithTag("EnemyGround");
        float shortDistanceG = Mathf.Infinity;
        GameObject closeEnemyG = null;

        foreach (GameObject enemyGround in enemyGrounds)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyGround.transform.position);
            if(shortDistanceG > distanceToEnemy)
            {
                shortDistanceG = distanceToEnemy;
                closeEnemyG = enemyGround;
            }
        }

        if(closeEnemyG != null && shortDistanceG <= 3)
        {
            target = closeEnemyG.transform;
        }
        else
        {
            target = null;
        }

        if(target == null)
        {
            return;
        }

        HP hp = target.GetComponent<HP>();
        hp.DealDamage(20);
    }
}
