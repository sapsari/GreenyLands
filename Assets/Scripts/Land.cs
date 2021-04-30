using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public Lane[] Lanes;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        var nameGen = new RandomNameGeneratorLibrary.PlaceNameGenerator();

        foreach (var lane in Lanes)
            foreach (var zone in lane.Zones)
                zone.Name = nameGen.GenerateRandomPlaceName();
    }
}
