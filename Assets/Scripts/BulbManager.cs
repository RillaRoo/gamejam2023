using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbManager : MonoBehaviour
{
    public SurfaceTrees surfaceType;
    public UndergroundTrees UndergroundType;
    public int originalSeedAmount;

    [SerializeField] bool isAvailable;
    public int SeedAmount;


    private void Start()
    {
        SeedAmount = originalSeedAmount;
    }
    private void Awake()
    {

    }
}
