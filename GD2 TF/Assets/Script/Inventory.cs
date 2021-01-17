using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int iron;
    public int copper;
    public int silicone;
    public int cpu;
    public int frag;
    public TextMeshProUGUI resourceIron;
    public TextMeshProUGUI resourceCopper;
    public TextMeshProUGUI resourceSilicone;
    public TextMeshProUGUI resourceCPU;
    public TextMeshProUGUI resourceFrag;

    // Start is called before the first frame update
    private void Start()
    {
        iron = 5;
        copper = 5;
        silicone = 5;
        cpu = 0;
        frag = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        resourceIron.text = iron.ToString();
        resourceCopper.text = copper.ToString();
        resourceSilicone.text = silicone.ToString();
        resourceCPU.text = cpu.ToString();
        resourceFrag.text = frag.ToString();
    }

    public void AddRessource(char ressource)
    {
        switch(ressource)
        {
            case 'i':
                iron++;
                break;
            case 'c':
                copper++;
                break;
            case 's':
                silicone++;
                break;
            case 'p':
                cpu++;
                break;
            case 'f':
                frag++;
                break;
        }
    }

    public void GetRessource(char ressource)
    {
        switch(ressource)
        {
            case 'i':
                iron--;
                break;
            case 'c':
                copper--;
                break;
            case 's':
                silicone--;
                break;
            case 'p':
                cpu++;
                break;
            case 'f':
                frag++;
                break;
        }
    }
}
