using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneKind { 
    Invalid,
    Village, Town, City, Forest, Field, Hills, Farm,

    SolarFarm, WindFarm, Geothermal, Dam, Battery,
    SolarFarmLevel2, SolarFarmLevel3,

    CityCoating, CitySolar,

    CoalPlant, OilPlant, GasPlant,
}

public class Zone : MonoBehaviour
{
    public Prefabs Prefabs;

    public string Name;
    public ZoneKind Kind;
    public int Energy;


    public int GreenEnergyProduction
    {
        get
        {
            if (Kind == ZoneKind.CoalPlant || Kind == ZoneKind.OilPlant || Kind == ZoneKind.GasPlant)
                return 0;
            else if (Energy > 0)
                return Energy;
            else
                return 0;
        }
    }

    public int DirtyEneryProduction
    {
        get
        {
            if (Kind == ZoneKind.CoalPlant || Kind == ZoneKind.OilPlant || Kind == ZoneKind.GasPlant)
                return Energy;
            else
                return 0;
        }
    }

    public int EnergyConsumption
    {
        get
        {
            if (Energy < 0)
                return Mathf.Abs(Energy);
            else
                return 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construct(ZoneKind kind)
    {
        this.Kind = kind;
        this.Energy = Data.GetEnergyLevelOf(kind);

        if (transform.childCount > 0)
        {
            var child = transform.GetChild(0);
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }

        var prefab = Prefabs.GetInstanceOf(kind);
        prefab.transform.parent = transform;
        prefab.transform.localScale = Vector3.one;
        prefab.transform.localPosition = Vector3.zero;
    }
}
