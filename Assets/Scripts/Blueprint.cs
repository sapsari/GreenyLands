using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BPKind { SolarFarm, WindFarm, Geothermal, Dam, Battery}

public class Blueprint : MonoBehaviour
{
    public BPKind Kind;

    //public Game

    public Dictionary<BPKind, ZoneKind[]> allowances = new Dictionary<BPKind, ZoneKind[]>()
    {
        { BPKind.SolarFarm, new ZoneKind[]{
            ZoneKind.Field, ZoneKind.Forest} },


    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
