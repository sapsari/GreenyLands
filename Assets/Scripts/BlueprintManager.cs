using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintManager : MonoBehaviour
{
    public Land Land;
    public int Count;

    public GameObject[] Widgets;

    public Blueprint[] Blueprints;


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
        //Blueprints = new Blueprint[Count];

        for (int i = 0; i < Count; i++)
        {
            //var bp = ScriptableObject.CreateInstance<Blueprint>();
            //var bp = new Blueprint() { Kind = BPKind.SolarFarm };
            var bp = Blueprints[i];
            bp.Kind = BPKind.SolarFarm;
            Blueprints[i] = bp;
            
            Widgets[i].SetActive(true);
            Widgets[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = bp.Kind.ToString();
        }

        for (int i = Count; i < Widgets.Length; i++)
            Widgets[i].SetActive(false);
    }

    public Blueprint Selected { get; set; }
    public void OnSelect(Blueprint bp)
    {
        if (Selected != null)
        {
            var curBut = Selected.GetComponent<Button>();
            curBut.colors = ColorBlock.defaultColorBlock;
        }

        this.Selected = bp;


        Color color = new Color32(0xBC, 0x54, 0x4B, 0xFF);
        var cb = new ColorBlock();
        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.pressedColor = color;
        cb.selectedColor = color;
        cb.disabledColor = color;
        cb.colorMultiplier = 1f;

        var button = Selected.GetComponent<Button>();
        button.colors = cb;
    }
}
