using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Land : MonoBehaviour
{
    public BlueprintManager BlueprintManager;
    public Slider Slider;
    public Lane[] Lanes;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void OnSelect(int zoneIndex)
    {
        Debug.Log($"zone {zoneIndex} selected");

        var bp = BlueprintManager.Selected;
        if(bp != null)
        {
            var zone = CurLane.Zones[zoneIndex];
            zone.Construct(bp.Kind);
        }
    }
}
