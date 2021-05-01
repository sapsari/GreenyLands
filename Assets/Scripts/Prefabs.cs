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

    public GameObject GetInstanceOf(ZoneKind zone)
    {
        return Instantiate(GetInstanceOfAux(zone));
    }


    GameObject GetInstanceOfAux(ZoneKind zone)
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
            case ZoneKind.SolarFarm:
                break;
            case ZoneKind.WindFarm:
                break;
            case ZoneKind.Geothermal:
                break;
            case ZoneKind.Dam:
                break;
            case ZoneKind.Battery:
                break;
            case ZoneKind.SolarFarmLevel2:
                break;
            case ZoneKind.SolarFarmLevel3:
                break;
            case ZoneKind.CityCoating:
                break;
            case ZoneKind.CitySolar:
                break;
            default:
                break;
        }
        return TownPrefabs[0];
        //return null;
    }
    
}
