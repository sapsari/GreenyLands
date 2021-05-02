using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public GameObject[] FieldPrefabs;
    public GameObject[] ForestPrefabs;
    public GameObject[] FarmPrefabs;
    public GameObject[] HillPrefabs;

    public GameObject[] TownPrefabs;
    public GameObject[] SolarFarmPrefabs;
    public GameObject[] WindFarmPrefabs;
    public GameObject[] WindFarmOnHillsPrefabs;

    public GameObject[] CoalPlantPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetInstanceOf(ZoneKind zone, ZoneKind land)
    {
        var arr = GetInstanceOfAux(zone, land);
        var rand = Random.Range(0, arr.Length);
        return Instantiate(arr[rand]);
    }


    GameObject[] GetInstanceOfAux(ZoneKind zone, ZoneKind land)
    {
        switch (zone)
        {
            case ZoneKind.Village:
                break;
            case ZoneKind.Town:
                return TownPrefabs;
            case ZoneKind.City:
                break;
            case ZoneKind.Forest:
                return ForestPrefabs;
            case ZoneKind.Field:
                return FieldPrefabs;
            case ZoneKind.Hills:
                return HillPrefabs;
            case ZoneKind.Farm:
                return FarmPrefabs;
            case ZoneKind.SolarFarm:
            case ZoneKind.SolarFarmLevel2:
            case ZoneKind.SolarFarmLevel3:
                return SolarFarmPrefabs;
            case ZoneKind.WindFarm:
            case ZoneKind.WindFarmLevel2:
            case ZoneKind.WindFarmLevel3:
                return land == ZoneKind.Hills ?
                    WindFarmOnHillsPrefabs : WindFarmPrefabs;
            case ZoneKind.Geothermal:
                break;
            case ZoneKind.Dam:
                break;
            case ZoneKind.Battery:
                break;
            case ZoneKind.CityCoating:
                break;
            case ZoneKind.CitySolar:
                break;
            case ZoneKind.CoalPlant:
            case ZoneKind.GasPlant:
            case ZoneKind.OilPlant:
                return CoalPlantPrefabs;
            default:
                break;
        }
        Debug.LogWarning(zone + " prefab not found");
        return ForestPrefabs;
        //return null;
    }
    
}