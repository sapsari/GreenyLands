using System;
using System.Collections.Generic;
using System.Linq;

public static class Data
{
    public static int GetEnergyLevelOf(ZoneKind kind)
    {
        if (EneryLevels.TryGetValue(kind, out int val))
            return val;
        else
            return 0;
    }

    public static Dictionary<ZoneKind, int> EneryLevels = new Dictionary<ZoneKind, int>()
    {
        { ZoneKind.CoalPlant, 2 },
        { ZoneKind.OilPlant, 2 },
        { ZoneKind.GasPlant, 2 },


        { ZoneKind.Village, -1 },
        { ZoneKind.Town, -2 },
        { ZoneKind.City, -5 },

        { ZoneKind.SolarFarm, 1 },
        { ZoneKind.SolarFarmLevel2, 2 },
        { ZoneKind.SolarFarmLevel3, 3 },
        { ZoneKind.WindFarm, 1 },
        { ZoneKind.WindFarmLevel2, 2 },
        { ZoneKind.WindFarmLevel3, 3 },
    };

    public static Dictionary<ZoneKind, ZoneKind[]> Allowances = new Dictionary<ZoneKind, ZoneKind[]>()
    {
        {
            ZoneKind.SolarFarm, new ZoneKind[]
            {
                ZoneKind.Field, ZoneKind.Forest, ZoneKind.Farm,
                ZoneKind.WindFarm,
            }
        },
        {
            ZoneKind.SolarFarmLevel2, new ZoneKind[]
            {
                ZoneKind.SolarFarm,
            }
        },
        {
            ZoneKind.SolarFarmLevel3, new ZoneKind[]
            {
                ZoneKind.SolarFarmLevel2,
            }
        },
        {
            ZoneKind.WindFarm, new ZoneKind[]
            {
                ZoneKind.Field, ZoneKind.Forest, ZoneKind.Farm, ZoneKind.Hills,
                ZoneKind.SolarFarm, ZoneKind.SolarFarmLevel2
            }
        },
        {
            ZoneKind.WindFarmLevel2, new ZoneKind[]
            {
                ZoneKind.WindFarm,
            }
        },
        {
            ZoneKind.WindFarmLevel3, new ZoneKind[]
            {
                ZoneKind.WindFarmLevel2,
            }
        },
    };
}

