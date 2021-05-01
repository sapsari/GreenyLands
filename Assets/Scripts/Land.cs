using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Land : MonoBehaviour
{
    public BlueprintManager BlueprintManager;
    public Slider Slider;
    public Lane[] Lanes;

    public UI_Top UI_Top;

    public Lane[] ActiveLanes { get; private set; }
    public int ActiveLaneCount { get; private set; }

    Lane CurLane => Slider.CurLane;



    public int GreenEnergyProduction => ActiveLanes.Sum(l => l.GreenEnergyProduction);
    public int DirtyEneryProduction => ActiveLanes.Sum(l => l.DirtyEneryProduction);
    public int EnergyConsumption => ActiveLanes.Sum(l => l.EnergyConsumption);


    // Start is called before the first frame update
    void Start()
    {
        Generate();
        SetActiveLaneCount(2);
        UI_Top.Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillEnergyArray(int[] energyLevels)
    {
        foreach (var lane in ActiveLanes)
            lane.FillEnergyArray(energyLevels);
    }

    void SetActiveLaneCount(int count)
    {
        var offset = Lanes.Length - count;
        ActiveLanes = new Lane[count];
        for (int i = 0; i < count; i++)
            ActiveLanes[i] = Lanes[i + offset];

        ActiveLaneCount = count;
    }

    public void Generate()
    {
        var nameGen = new RandomNameGeneratorLibrary.PlaceNameGenerator();

        foreach (var lane in Lanes)
            foreach (var zone in lane.Zones)
                zone.Name = nameGen.GenerateRandomPlaceName();

        
        for (int laneIndex = 0; laneIndex < Lanes.Length; laneIndex++)
        {
            var lane = Lanes[laneIndex];

            if (laneIndex == Lanes.Length - 1)
            {
                for (int i = 1; i < lane.Zones.Length; i++)
                    lane.Zones[i].Construct(getGreenFlat());
            }
            else
            {
                for (int i = 1; i < lane.Zones.Length; i++)
                    lane.Zones[i].Construct(getGreen());
            }
        }

        var rearLane = Lanes[Lanes.Length - 1];
        rearLane.Zones[0].Construct(ZoneKind.CoalPlant);

        var lane2 = Lanes[Lanes.Length - 2];
        lane2.Zones[1].Construct(ZoneKind.Town);

        ZoneKind getGreen() =>
            getRandom(ZoneKind.Field, ZoneKind.Farm, ZoneKind.Forest, ZoneKind.Hills);
        ZoneKind getGreenFlat() =>
            getRandom(ZoneKind.Field, ZoneKind.Farm, ZoneKind.Forest);
        ZoneKind getRandom(params ZoneKind[] kinds) =>
            kinds[Random.Range(0, kinds.Length)];
    }

    public void OnSelect(int zoneIndex)
    {
        Debug.Log($"zone {zoneIndex} selected");

        var bp = BlueprintManager.Selected;
        if(bp != null)
        {
            var zone = CurLane.Zones[zoneIndex];
            zone.Construct(bp.Kind);
            UI_Top.Refresh();
        }
    }
}
