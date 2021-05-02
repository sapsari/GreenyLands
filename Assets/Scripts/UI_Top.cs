using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Top : MonoBehaviour
{
    public Land Land;

    public Sprite Coal;
    public Sprite Oil;
    public Sprite Gas;

    public Sprite Solar;
    public Sprite Wind;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh(out bool isAllGreen)
    {
        int count = Land.EnergyConsumption;

        int[] productions = new int[(int)ZoneKind.Count];
        Land.FillEnergyArray(productions);

        Debug.Log("Energy Consumption: " + Land.EnergyConsumption);
        Debug.Log("Solar: " + productions[(int)ZoneKind.SolarFarm]);

        isAllGreen = true;

        int i = 0;
        for (; i < count; i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(true);

            var image = child.GetComponent<UnityEngine.UI.Image>();

            if (productions[(int)ZoneKind.SolarFarm] > 0)
            {
                productions[(int)ZoneKind.SolarFarm]--;
                image.sprite = Solar;
            }
            else if (productions[(int)ZoneKind.WindFarm] > 0)
            {
                productions[(int)ZoneKind.WindFarm]--;
                image.sprite = Wind;
            }
            else if (productions[(int)ZoneKind.GasPlant] > 0)
            {
                productions[(int)ZoneKind.GasPlant]--;
                image.sprite = Gas;
                isAllGreen = false;
            }
            else if (productions[(int)ZoneKind.OilPlant] > 0)
            {
                productions[(int)ZoneKind.OilPlant]--;
                image.sprite = Oil;
                isAllGreen = false;
            }
            else if (productions[(int)ZoneKind.CoalPlant] > 0)
            {
                productions[(int)ZoneKind.CoalPlant]--;
                image.sprite = Coal;
                isAllGreen = false;
            }

        }

        for(;i<transform.childCount;i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }
}
