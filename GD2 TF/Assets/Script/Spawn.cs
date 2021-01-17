using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Quaternion defaultQ;
    private float timer;
    public GameObject ground;
    public GameObject fly;

    void Start()
    {
        defaultQ = new Quaternion(0,0,0,0);
        timer = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        int totalenemies = 0;

        GameObject[] turrets = GameObject.FindGameObjectsWithTag("EnemyGround");
        GameObject[] players = GameObject.FindGameObjectsWithTag("EnemyFly");

        foreach (GameObject turret in turrets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turret.transform.position);
            if(distanceToEnemy <= 10)
            {
                totalenemies++;
            }
        }

        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToEnemy <= 10)
            {
                totalenemies++;
            }
        }

        if(totalenemies < 10)
        {
            if(Time.time - timer > 5f)
            {
                timer = Time.time;
                int random = Random.Range(0,2);
                switch (random)
                {
                    case 0:
                        Instantiate(ground, transform.position, defaultQ);
                        break;
                    case 1:
                        Instantiate(fly, transform.position, defaultQ);
                        break;
                }
            }
        }
    }
}
