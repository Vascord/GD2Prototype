using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    private float dashTime;
    private readonly float moveLimiter = 0.7f;
    public float cooldown;
    [SerializeField] private float runSpeed;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        dashTime = 0f;
    }

    void Update()
    {
        cooldown = Time.time - dashTime;

        // Gives a value between -1 and 1
        if(cooldown > 1f)
        {
            runSpeed = 10f;
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        }

        if(cooldown < 1f && cooldown > 0.5f)
        {
            runSpeed = 5f;
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        }

        if (horizontal != 0 && vertical != 0  && cooldown > 0.5f)
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (horizontal != 0 || vertical != 0)
        {
            if(Input.GetButtonDown("Dash") && cooldown > 1.5f)
            {
                dashTime = Time.time;
                runSpeed *= 1.5f;
            }
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
