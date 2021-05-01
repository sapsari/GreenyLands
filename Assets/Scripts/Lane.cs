using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Zone[] Zones;


    public int GreenEnergyProduction => Zones.Sum(z => z.GreenEnergyProduction);
    public int DirtyEneryProduction => Zones.Sum(z => z.DirtyEneryProduction);
    public int EnergyConsumption => Zones.Sum(z => z.EnergyConsumption);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
