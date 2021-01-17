using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlasma : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyGrounds = GameObject.FindGameObjectsWithTag("EnemyGround");
        GameObject[] enemyFlys = GameObject.FindGameObjectsWithTag("EnemyFly");
        float shortDistanceG = Mathf.Infinity;
        float shortDistanceF = Mathf.Infinity;
        GameObject closeEnemyG = null;
        GameObject closeEnemyF = null;

        foreach (GameObject enemyGround in enemyGrounds)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyGround.transform.position);
            if(shortDistanceG > distanceToEnemy)
            {
                shortDistanceG = distanceToEnemy;
                closeEnemyG = enemyGround;
            }
        }

        foreach (GameObject enemyFly in enemyFlys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyFly.transform.position);
            if(shortDistanceF > distanceToEnemy)
            {
                shortDistanceF = distanceToEnemy;
                closeEnemyF = enemyFly;
            }
        }

        if(closeEnemyG != null && shortDistanceG <= 5)
        {
            target = closeEnemyG.transform;
        }
        else if(closeEnemyF != null && shortDistanceF <= 5)
        {
            target = closeEnemyF.transform;
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
        hp.DealDamage(10);
    }
}
