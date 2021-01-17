using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShotgun : MonoBehaviour
{
    public Transform target;
    private float timer = 0f;

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

        if(Time.time - timer > 0.5f)
        {
            HP hp = target.GetComponent<HP>();
            hp.DealDamage(100);
            timer = Time.time;
        }
    }
}
