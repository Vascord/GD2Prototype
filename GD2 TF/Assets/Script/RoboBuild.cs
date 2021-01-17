using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboBuild : MonoBehaviour
{
    public Transform target;
    // public GameObject inventory;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyFlys = GameObject.FindGameObjectsWithTag("Turret");
        GameObject[] enemyFlyts = GameObject.FindGameObjectsWithTag("TurretBuild");
        GameObject[] enemyFlyfs = GameObject.FindGameObjectsWithTag("TurretGrab");
        float shortDistanceF = Mathf.Infinity;
        float shortDistanceFT = Mathf.Infinity;
        float shortDistanceFF = Mathf.Infinity;
        float dist = Mathf.Infinity;
        float distT = Mathf.Infinity;
        float distF = Mathf.Infinity;
        GameObject closeEnemyF = null;
        GameObject closeEnemyFT = null;
        GameObject closeEnemyFF = null;

        foreach (GameObject enemyFly in enemyFlys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyFly.transform.position);
            HP hp = enemyFly.GetComponent<HP>();
            if(shortDistanceF > hp.hp)
            {
                shortDistanceF = hp.hp;
                dist = distanceToEnemy;
                closeEnemyF = enemyFly;
            }
        }
        foreach (GameObject enemyFlyf in enemyFlyfs)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyFlyf.transform.position);
            HP hp = enemyFlyf.GetComponent<HP>();
            if(shortDistanceFF > hp.hp)
            {
                shortDistanceFF = hp.hp;
                distF = distanceToEnemy;
                closeEnemyFF = enemyFlyf;
            }
        }
        foreach (GameObject enemyFlyt in enemyFlyts)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyFlyt.transform.position);
            HP hp = enemyFlyt.GetComponent<HP>();
            if(shortDistanceFT > hp.hp)
            {
                shortDistanceFT = hp.hp;
                distT = distanceToEnemy;
                closeEnemyFT = enemyFlyt;
            }
        }

        if(closeEnemyF != null && dist <= 5)
        {
            target = closeEnemyF.transform;
        }
        else if(closeEnemyFF != null && distF <= 5)
        {
            target = closeEnemyFF.transform;
        }
        else if(closeEnemyFT != null && distT <= 5)
        {
            target = closeEnemyFT.transform;
        }
        else
        {
            target = null;
        }

        if(target == null)
        {
            return;
        }

        if(Time.time - timer > 2.5f)
        {
            HP hp = target.GetComponent<HP>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Inventory inventorys = player.GetComponentInChildren<Inventory>();
            if(target.GetComponent<TurretAntiAereal>())
            {
                timer = Time.time;
                if(hp.hp < 100 && inventorys.silicone > 0)
                {
                    hp.YesHealDamage(50);
                    inventorys.GetRessource('s');
                }
            }
            else if(target.GetComponent<TurretPlasma>())
            {
                timer = Time.time;
                if(hp.hp < 100 && inventorys.copper > 0)
                {
                    hp.YesHealDamage(50);
                    inventorys.GetRessource('c');
                }
            }
            else if(target.GetComponent<TurretShotgun>())
            {
                timer = Time.time;
                if(hp.hp < 100 && inventorys.silicone > 0)
                {
                    hp.YesHealDamage(50);
                    inventorys.GetRessource('s');
                }
            }
            else if(target.GetComponent<RoboBuild>())
            {
                timer = Time.time;
                if(hp.hp < 100 && inventorys.iron > 0)
                {
                    hp.YesHealDamage(50);
                    inventorys.GetRessource('i');
                }
            }
            else if(target.GetComponent<GrabRobo>())
            {
                timer = Time.time;
                if(hp.hp < 100 && inventorys.iron > 0)
                {
                    hp.YesHealDamage(50);
                    inventorys.GetRessource('i');
                }
            }
        }
    }
}
