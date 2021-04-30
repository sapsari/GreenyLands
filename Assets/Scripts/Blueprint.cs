using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BPKind { 
    SolarFarm, WindFarm, Geothermal, Dam, Battery,
    SolarFarmLevel2, SolarFarmLevel3,
}

public class Blueprint : MonoBehaviour
{
    public BPKind Kind;

    BlueprintManager manager;
    //public Game

    public Dictionary<BPKind, ZoneKind[]> allowances = new Dictionary<BPKind, ZoneKind[]>()
    {
        { 
            BPKind.SolarFarm, new ZoneKind[]
            {
                ZoneKind.Field, ZoneKind.Forest
            }
        },
        {
            BPKind.SolarFarmLevel2, new ZoneKind[]
            {
            }
        }
    };

    public void Start()
    {
        manager = FindObjectOfType<BlueprintManager>();
    }

    public void OnSelect()
    {
        manager.OnSelect(this);
    }
}
