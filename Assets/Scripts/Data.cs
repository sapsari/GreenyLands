using System;
using System.Collections.Generic;
using System.Linq;

public static class Data
{
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

