using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blocos : MonoBehaviour
{
    public Transform target;
    private float timer;
    public int effenciency;
    public int autonomia;
    public TextMeshProUGUI effenciencyUI;
    public TextMeshProUGUI autonomiaUI;

    // Start is called before the first frame update
    void Start()
    {
        effenciency = 0;
        autonomia = 0;
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyGs = GameObject.FindGameObjectsWithTag("EnemyGround");
        GameObject[] enemyFs = GameObject.FindGameObjectsWithTag("EnemyGround");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float shortDistanceG = Mathf.Infinity;
        float shortDistanceF = Mathf.Infinity;
        float shortDistanceP = Mathf.Infinity;
        GameObject closeEnemyG = null;
        GameObject closeEnemyF = null;
        GameObject closePlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if(shortDistanceP > distanceToEnemy)
            {
                shortDistanceP = distanceToEnemy;
                closePlayer = player;
            }
        }

        foreach (GameObject enemyG in enemyGs)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyG.transform.position);
            if(shortDistanceG > distanceToEnemy)
            {
                shortDistanceG = distanceToEnemy;
                closeEnemyG = enemyG;
            }
        }

        foreach (GameObject enemyF in enemyFs)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyF.transform.position);
            if(shortDistanceF > distanceToEnemy)
            {
                shortDistanceF = distanceToEnemy;
                closeEnemyF = enemyF;
            }
        }

        if(closeEnemyG != null && shortDistanceG <= 10)
        {
            target = closeEnemyG.transform;
            if(Time.time - timer > 1f)
            {
                timer = Time.time;
                if(effenciency > 0)
                    effenciency--;
                if(autonomia > 0) 
                    autonomia--;
            }
        }
        if(closeEnemyF != null && shortDistanceF <= 10)
        {
            target = closeEnemyF.transform;
            if(Time.time - timer > 1f)
            {
                timer = Time.time;
                if(effenciency > 0)
                    effenciency--;
                if(autonomia > 0) 
                    autonomia--;
            }
        }
        if(closePlayer != null && shortDistanceP <= 10)
        {
            effenciencyUI.text = effenciency.ToString();
            autonomiaUI.text = autonomia.ToString();
            target = null;
        }

        if(target != null)
        {
            return;
        }

        if(Time.time - timer > 1f)
        {
            timer = Time.time;

            effenciency++;

            if(effenciency >= 95 && shortDistanceP >= 5)
            {
                autonomia++;
            }
        }
    }
}
