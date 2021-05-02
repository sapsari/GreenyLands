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
    public UI_Popup UI_Popup;

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
        UI_Top.Refresh(out _);

        UI_Popup.gameObject.SetActive(true);
        UI_Popup.Display("Let's build some renewable power plants!", "Begin");
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
                for (int i = 0; i < lane.Zones.Length; i++)
                {
                    lane.Zones[i].Construct(getGreenFlat());
                    lane.Zones[i].Kind = ZoneKind.Invalid;// to prevent construction
                }
            }
            else
            {
                for (int i = 0; i < lane.Zones.Length; i++)
                    lane.Zones[i].Construct(getGreen());
            }
        }

        var rearLane = Lanes[Lanes.Length - 1];
        rearLane.Zones[0].Construct(ZoneKind.CoalPlant);

        var lane2 = Lanes[Lanes.Length - 2];
        lane2.Zones[Random.Range(0, 3)].Construct(ZoneKind.Town);

        var lane3 = Lanes[Lanes.Length - 3];
        lane3.Zones[Random.Range(0, 3)].Construct(ZoneKind.Town);
        lane3.Zones[Random.Range(3, 5)].Construct(ZoneKind.Town);

        var lane4 = Lanes[Lanes.Length - 4];
        lane4.Zones[Random.Range(0, 3)].Construct(ZoneKind.City);
        lane4.Zones[Random.Range(3, 5)].Construct(ZoneKind.Town);

        var lane5 = Lanes[Lanes.Length - 5];
        lane5.Zones[Random.Range(0, 2)].Construct(ZoneKind.City);
        lane5.Zones[Random.Range(2, 4)].Construct(ZoneKind.City);

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
            if (zone.Construct(bp.Kind))
            {

                UI_Top.Refresh(out bool allGreen);
                if (allGreen)
                {
                    if (ActiveLaneCount == Lanes.Length)
                        UI_Popup.Display(
                        "Congratulations. We are now all powered by renewable energy!",
                        "Quit",
                        Application.Quit);
                    else
                        UI_Popup.Display(
                        "We have phased out fossil fuel for our energy!\nLet's move to the next region.",
                        "Next Region",
                        Progress);
                }


                BlueprintManager.Generate();
            }
        }
    }

    void Progress()
    {
        SetActiveLaneCount(ActiveLaneCount + 1);
        for (int i = 0; i < ActiveLaneCount; i++)
            Slider.SlideUp();

        var rearLane = Lanes[Lanes.Length - 1];
        rearLane.Zones[ActiveLaneCount - 2].Construct(ZoneKind.CoalPlant);

        UI_Top.Refresh(out _);
    }

    public void UpdateConstructionHintArrows()
    {
        foreach(var lane in Lanes)
        {
            if (lane == CurLane)
                lane.SetArrowsVisibility(BlueprintManager.Selected == null ? ZoneKind.Invalid
                    : BlueprintManager.Selected.Kind);
            else
                lane.SetArrowsVisibility(ZoneKind.Invalid);
        }
    }
}
