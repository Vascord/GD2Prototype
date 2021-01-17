using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRobo : MonoBehaviour
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

        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Respawn");
        float shortDistanceT = Mathf.Infinity;
        GameObject closeTurret = null;

        foreach (GameObject turret in turrets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turret.transform.position);
            if(shortDistanceT > distanceToEnemy)
            {
                shortDistanceT = distanceToEnemy;
                closeTurret = turret;
            }
        }

        if(closeTurret != null && shortDistanceT <= 5)
        {
            target = closeTurret.transform;
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
