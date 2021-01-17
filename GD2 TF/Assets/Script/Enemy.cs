using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(20f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = body.velocity;

        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        GameObject[] turretsG = GameObject.FindGameObjectsWithTag("TurretBuild");
        GameObject[] turretsB = GameObject.FindGameObjectsWithTag("TurretGrab");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float shortDistanceT = Mathf.Infinity;
        float shortDistanceTG = Mathf.Infinity;
        float shortDistanceTB = Mathf.Infinity;
        float shortDistanceP = Mathf.Infinity;
        GameObject closeTurret = null;
        GameObject closeTurretG = null;
        GameObject closeTurretB = null;
        GameObject closePlayer = null;

        foreach (GameObject turret in turrets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turret.transform.position);
            if(shortDistanceT > distanceToEnemy)
            {
                shortDistanceT = distanceToEnemy;
                closeTurret = turret;
            }
        }

        foreach (GameObject turretB in turretsB)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turretB.transform.position);
            if(shortDistanceTB > distanceToEnemy)
            {
                shortDistanceTB = distanceToEnemy;
                closeTurretB = turretB;
            }
        }

        foreach (GameObject turretG in turretsG)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turretG.transform.position);
            if(shortDistanceTG > distanceToEnemy)
            {
                shortDistanceTG = distanceToEnemy;
                closeTurretG = turretG;
            }
        }

        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if(shortDistanceP > distanceToEnemy)
            {
                shortDistanceP = distanceToEnemy;
                closePlayer = player;
            }
        }

        if(closeTurret != null && shortDistanceT <= 5)
        {
            target = closeTurret.transform;
        }
        else if(closeTurretB != null && shortDistanceTB <= 5)
        {
            target = closeTurretB.transform;
        }
        else if(closeTurretG != null && shortDistanceTG <= 5)
        {
            target = closeTurretG.transform;
        }
        else if(closePlayer != null && shortDistanceP <= 5)
        {
            target = closePlayer.transform;
        }
        else
        {
            target = null;
        }

        if(target == null)
        {
            body.velocity =new Vector2(0, 0);
            return;
        }

        currentVelocity.x = (target.position.x - transform.position.x);
        currentVelocity.y = (target.position.y - transform.position.y);

        body.velocity = currentVelocity;
    }
}
