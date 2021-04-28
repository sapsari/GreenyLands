using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public GameObject[] TownPrefabs;


    public GameObject[] SolarFarmPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetInstanceOf(BPKind blueprint)
    {
        /*
        switch (blueprint)
        {
            case BPKind.SolarFarm:
                return null;
            default:
                return null;

        }*/
        return Instantiate(TownPrefabs[0]);
    }

    public GameObject GetInstanceOf(ZoneKind zone)
    {
        switch (zone)
        {
            case ZoneKind.Village:
                break;
            case ZoneKind.Town:
                return TownPrefabs[0];
            case ZoneKind.City:
                break;
            case ZoneKind.Forest:
                break;
            case ZoneKind.Field:
                break;
            case ZoneKind.Hills:
                break;
            default:
                break;
        }
        return TownPrefabs[0];
        //return null;
    }
    
}
