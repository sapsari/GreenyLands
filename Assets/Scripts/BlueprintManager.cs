using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManager : MonoBehaviour
{
    public Land Land;
    public int Count;

    public GameObject[] Widgets;

    Blueprint[] Blueprints;


    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        Blueprints = new Blueprint[Count];

        for (int i = 0; i < Count; i++)
        {
            var bp = ScriptableObject.CreateInstance<Blueprint>();
            //var bp = new Blueprint() { Kind = BPKind.SolarFarm };
            bp.Kind = BPKind.SolarFarm;
            Blueprints[i] = bp;
            
            Widgets[i].SetActive(true);
            Widgets[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = bp.Kind.ToString();
        }

        for (int i = Count; i < Widgets.Length; i++)
            Widgets[i].SetActive(false);
    }
}
