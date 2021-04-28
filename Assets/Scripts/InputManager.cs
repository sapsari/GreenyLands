using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Slider.SlideDown();
        else if(Input.GetKeyDown(KeyCode.UpArrow))
            Slider.SlideUp();
    }


}
