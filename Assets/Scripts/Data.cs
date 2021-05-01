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
        { ZoneKind.WindFarm, 1 },
    };

    public static ZoneKind[][] Allow = new ZoneKind[][]
    {
        new ZoneKind[]
        {
            
        }
    };

    public static Dictionary<ZoneKind, ZoneKind[]> Allowances = new Dictionary<ZoneKind, ZoneKind[]>()
    {
        {
            ZoneKind.SolarFarm, new ZoneKind[]
            {
                ZoneKind.Field, ZoneKind.Forest,
            }
        },
        {
            ZoneKind.SolarFarmLevel2, new ZoneKind[]
            {
                ZoneKind.SolarFarm,
            }
        }
    };
}

