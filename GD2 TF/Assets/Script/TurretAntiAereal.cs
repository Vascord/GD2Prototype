﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAntiAereal : MonoBehaviour
{
    public Transform target;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyFlys = GameObject.FindGameObjectsWithTag("EnemyFly");
        float shortDistanceF = Mathf.Infinity;
        GameObject closeEnemyF = null;

        foreach (GameObject enemyFly in enemyFlys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyFly.transform.position);
            if(shortDistanceF > distanceToEnemy)
            {
                shortDistanceF = distanceToEnemy;
                closeEnemyF = enemyFly;
            }
        }

        if(closeEnemyF != null && shortDistanceF <= 6)
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

        if(Time.time - timer > 0.2f)
        {
            HP hp = target.GetComponent<HP>();
            hp.DealDamage(25);
            timer = Time.time;
        }
    }
}
