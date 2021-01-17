using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class HP : MonoBehaviour
{
    [NaughtyAttributes.TagAttribute]
    new public string       tag;
    [SerializeField] private GameObject ferro;
    [SerializeField] private GameObject copper;
    [SerializeField] private GameObject silicone;
    private Quaternion defaultQ;
    public float hp = 100;
    public TextMeshProUGUI health;
    float timer = 0.0f;

    public bool isInvulnerable
    {
        get
        {
            return timer > 0;
        }
        set
        {
            if (value) timer = 0.1f;
            else timer = 0;
        }
    }

    void Start()
    {
        if (gameObject.tag == tag)
        {
            health.text = hp.ToString();
        }
        defaultQ = new Quaternion(0,0,0,0);
    }

    void Update()
    {
        if(timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

        if((gameObject.tag == tag) && (hp <= 0))
        {
            HealDamage();
            gameObject.transform.position = new Vector3 (0,0,0);
        }
    }

    public void DealDamage(float damage)
    {
        if(isInvulnerable) return;
        
        if(hp <= 0) return;

        hp = hp - damage;
        isInvulnerable = true;

        if (gameObject.tag == tag)
        {
            health.text = hp.ToString();
        }

        if ((hp <= 0) && (gameObject.tag == "EnemyGround" || gameObject.tag == "EnemyFly"))
        {
            int loot = Random.Range(1,14);
            switch(loot)
            {
                case 2:
                    Instantiate(ferro, transform.position, defaultQ);
                    break;
                case 5:
                    Instantiate(ferro, transform.position, defaultQ);
                    break;
                case 6:
                    Instantiate(copper, transform.position, defaultQ);
                    break;
                case 3:
                    Instantiate(copper, transform.position, defaultQ);
                    break;
                case 4:
                    Instantiate(silicone, transform.position, defaultQ);
                    break;
                case 7:
                    Instantiate(ferro, transform.position, defaultQ);
                    Instantiate(ferro, transform.position, defaultQ);
                    break;
                case 8:
                    Instantiate(copper, transform.position, defaultQ);
                    Instantiate(silicone, transform.position, defaultQ);
                    break;
                case 9:
                    Instantiate(silicone, transform.position, defaultQ);
                    Instantiate(ferro, transform.position, defaultQ);
                    break;
                case 10:
                    Instantiate(silicone, transform.position, defaultQ);
                    Instantiate(copper, transform.position, defaultQ);
                    Instantiate(silicone, transform.position, defaultQ);
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
        else if ((hp <= 0) && (gameObject.tag != tag))
        {
            Destroy(gameObject);
        }

    }

    public void HealDamage()
    {
        hp = 100;
        health.text = hp.ToString();
    }
    public void YesHealDamage(int heal)
    {
        hp += heal;
    }
}
