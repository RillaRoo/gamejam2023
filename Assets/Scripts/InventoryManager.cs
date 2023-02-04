using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    private PlayerBottom playerB;
    private PlayerTop playerT;

    int[] plantInventoryAmountB = new int[6];
    int[] plantInventoryAmountT = new int[6];

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void RelinkRefrences()
    {
        playerB = GameObject.FindGameObjectWithTag("Mole").GetComponent<PlayerBottom>();
        playerT = GameObject.FindGameObjectWithTag("Cat").GetComponent<PlayerTop>();
    }

    public void ChangeBombAmountBottom(int amount)
    {
        plantInventoryAmountB[0] += amount;
    }

    public void ChangeBombAmountTop(int amount)
    {
        plantInventoryAmountT[0] += amount;
    }

}
