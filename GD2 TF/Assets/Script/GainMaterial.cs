using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GainMaterial : MonoBehaviour
{
    [Tag]
    new public string       tag;
    [Tag]
    new public string       tagRobot;
    [SerializeField] char typeOfRessource;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == collision.tag || tagRobot == collision.tag)
        {
            Destroy(gameObject);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Inventory bag = player.GetComponentInChildren<Inventory>();
            bag.AddRessource(typeOfRessource);
        }
    }
}