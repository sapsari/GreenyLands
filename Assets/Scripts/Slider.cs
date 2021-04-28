using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slider : MonoBehaviour
{
    public Camera Camera;
    public Lane[] Lanes;
    // lanes[0] is front lane, lanes[4] is rear lane


    int laneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SlideUp()
    {
        Slide(laneIndex - 1);
    }
    public void SlideDown()
    {
        Slide(laneIndex + 1);
    }

    void Slide(int laneIndex)
    {
        const float duration = 1f;

        if (laneIndex < 0 || laneIndex >= Lanes.Length)
            return;
        else
            this.laneIndex = laneIndex;

        Camera.transform.DOMoveZ(-50 + 80 * laneIndex, duration);

        for(int i=laneIndex;i<Lanes.Length;i++)
        {
            Lanes[i].transform.DOScale(Mathf.Pow(.8f, i - laneIndex), duration);
        }
    }
}
