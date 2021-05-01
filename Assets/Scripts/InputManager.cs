using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Slider Slider;
    public Land Land;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float previousScrollDelta;
    // Update is called once per frame
    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.Keypad2) ||
            (previousScrollDelta == 0 && Input.mouseScrollDelta.y < 0f)
            )
            Slider.SlideDown();
        else if (
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.Keypad8) ||
            (previousScrollDelta == 0 && Input.mouseScrollDelta.y > 0f)
            )
            Slider.SlideUp();

        /*
        if (Input.GetKeyDown(KeyCode.Space))
            Land.Lanes[0].Zones[0].Construct(new Blueprint());
        */

        previousScrollDelta = Input.mouseScrollDelta.y;

    }


}
