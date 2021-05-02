using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ZoneKind { 
    Invalid,
    Village, Town, City,
    Forest, Field, Hills, Farm,

    SolarFarm, WindFarm, Geothermal, Dam, Battery,
    SolarFarmLevel2, SolarFarmLevel3,
    WindFarmLevel2, WindFarmLevel3,

    CityCoating, CitySolar,

    CoalPlant, OilPlant, GasPlant,

    Count,
}

public class Zone : MonoBehaviour
{
    public Prefabs Prefabs;

    public string Name;
    public ZoneKind Kind;
    public int Energy;

    public string DisplayName
    {
        get
        {
            if (Kind == ZoneKind.Village || Kind == ZoneKind.Town || Kind == ZoneKind.City)
                return Name;
            else if (Kind == ZoneKind.SolarFarm || Kind == ZoneKind.SolarFarmLevel2 || Kind == ZoneKind.SolarFarmLevel3)
                return ZoneKind.SolarFarm.ToString();
            else if (Kind == ZoneKind.WindFarm || Kind == ZoneKind.WindFarmLevel2 || Kind == ZoneKind.WindFarmLevel3)
                return ZoneKind.WindFarm.ToString();
            else if (Kind == ZoneKind.CoalPlant || Kind == ZoneKind.GasPlant || Kind == ZoneKind.OilPlant)
                return Kind.ToString();
            else
                return string.Empty;
        }
    }

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

    public void FillEnergyArray(int[] eneryLevels)
    {
        var kind = Kind;
        switch(Kind)
        {
            case ZoneKind.SolarFarmLevel2:
            case ZoneKind.SolarFarmLevel3:
                kind = ZoneKind.SolarFarm;
                break;
        }

        eneryLevels[(int)kind] += Energy;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Construct(ZoneKind kind)
    {
        if (Data.Allowances.ContainsKey(kind) && !Data.Allowances[kind].Contains(this.Kind))
            return false;

        var previousKind = this.Kind;

        this.Kind = kind;
        this.Energy = Data.GetEnergyLevelOf(kind);

        if (transform.childCount > 0)
        {
            var child = transform.GetChild(0);
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }

        var prefab = Prefabs.GetInstanceOf(kind, previousKind);
        var localScale = prefab.transform.localScale;
        var localPos = prefab.transform.localPosition;
        prefab.transform.parent = transform;
        //prefab.transform.localScale = Vector3.one;
        prefab.transform.localScale = localScale;
        //prefab.transform.localPosition = Vector3.zero;
        prefab.transform.localPosition = localPos;

        return true;
    }
}
