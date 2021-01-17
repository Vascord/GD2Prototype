using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTurret : MonoBehaviour
{
    private bool turretUI;

    [SerializeField] private GameObject UIturret;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject plasma;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject aerial;
    [SerializeField] private GameObject build;
    [SerializeField] private GameObject grab;
    private Quaternion defaultQ;

    private Inventory ressources;

    // Start is called before the first frame update
    void Start()
    {
        turretUI = false;
        ressources = inventory.GetComponent<Inventory>();
        defaultQ = new Quaternion(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("TurretInventory") && !turretUI)
        {
            gameObject.GetComponent<PlayerMouvement>().enabled = false;
            turretUI = true;
        }
        else if(Input.GetButtonDown("TurretInventory") && turretUI)
        {
            gameObject.GetComponent<PlayerMouvement>().enabled = true;
            turretUI = false;
        }

        if(turretUI)
        {
            UIturret.SetActive(true);
            AppearTurret();
        }
        else
        {
            UIturret.SetActive(false);
        }
    }

    private void AppearTurret()
    {
        if(Input.GetButtonDown("Turret1"))
        {
            if(ressources.iron >= 2 && ressources.copper >= 1)
            {
                ressources.iron -= 2;
                ressources.copper -= 1;
                Instantiate(plasma, gameObject.transform.position, defaultQ);
                gameObject.GetComponent<PlayerMouvement>().enabled = true;
                turretUI = false;
            }
        }
        else if(Input.GetButtonDown("Turret2"))
        {
            if(ressources.iron >= 6 && ressources.silicone >= 2)
            {
                ressources.iron -= 6;
                ressources.silicone -= 2;
                Instantiate(shotgun, gameObject.transform.position, defaultQ);
                gameObject.GetComponent<PlayerMouvement>().enabled = true;
                turretUI = false;
            }
        }
        else if(Input.GetButtonDown("Turret3"))
        {
            if(ressources.iron >= 3 && ressources.copper >= 5)
            {
                ressources.iron -= 3;
                ressources.copper -= 5;
                Instantiate(aerial, gameObject.transform.position, defaultQ);
                gameObject.GetComponent<PlayerMouvement>().enabled = true;
                turretUI = false;
            }
        }
        else if(Input.GetButtonDown("Turret4"))
        {
            if(ressources.iron >= 1 && ressources.copper >= 1 && ressources.silicone >= 3)
            {
                ressources.iron -= 1;
                ressources.copper -= 1;
                ressources.silicone -= 3;
                Instantiate(grab, gameObject.transform.position, defaultQ);
                gameObject.GetComponent<PlayerMouvement>().enabled = true;
                turretUI = false;
            }
        }
        else if(Input.GetButtonDown("Turret5"))
        {
            if(ressources.iron >= 2 && ressources.copper >= 3 && ressources.silicone >= 1)
            {
                ressources.iron -= 2;
                ressources.copper -= 3;
                ressources.silicone -= 1;
                Instantiate(build, gameObject.transform.position, defaultQ);
                gameObject.GetComponent<PlayerMouvement>().enabled = true;
                turretUI = false;
            }
        }
    }
}
