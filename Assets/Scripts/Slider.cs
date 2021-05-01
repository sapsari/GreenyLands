using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Slider : MonoBehaviour
{
    public Camera Camera;
    
    // lanes[0] is front lane, lanes[4] is rear lane

    public Info[] Infos;
    public Button[] ZoneButtons;

    Land Land;
    Lane[] Lanes => Land.Lanes;
    int laneIndex;

    public Lane CurLane => Lanes[laneIndex];


    // Start is called before the first frame update
    void Start()
    {
        this.Land = this.GetComponent<Land>();
        Slide(3, forced: true);
        DOTween.CompleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform zone in CurLane.transform)
        {
            //var pos = Camera.WorldToScreenPoint(zone.position);
            //pos.z = 0f;

            var pos = zone.position;
            Debug.DrawLine(pos, pos + Vector3.one * 10f, Color.red);

            //Debug.
        }
        Debug.DrawLine(Vector3.zero, Vector3.one * 1000, Color.red);

        for (int i = 0; i < 9; i++)
            NewMethod(i);

        void NewMethod(int index)
        {
            if (index >= Infos.Length)
                return;

            Infos[index].gameObject.SetActive(index < CurLane.transform.childCount);
            ZoneButtons[index].gameObject.SetActive(index < CurLane.transform.childCount);
            if (index >= CurLane.transform.childCount)
                return;

            var p = Infos[index].transform.position;
            var x = Camera.WorldToScreenPoint(CurLane.transform.GetChild(index).position).x;
            p.x = x;
            Infos[index].transform.position = p;

            p = ZoneButtons[index].transform.position;
            p.x = x;
            ZoneButtons[index].transform.position = p;

            var text = Infos[index].transform.GetChild(0).GetComponent<Text>();
            text.text = CurLane.Zones[index].Name;
        }

    }

    public void SlideUp()
    {
        Slide(laneIndex - 1);
    }
    public void SlideDown()
    {
        Slide(laneIndex + 1);
    }

    void Slide(int laneIndex, bool forced = false)
    {
        const float duration = 1f;

        if (laneIndex < 0 || laneIndex >= Lanes.Length)
            return;
        else if (!forced && Lanes.Length - laneIndex > Land.ActiveLaneCount)
            return;
        else
            this.laneIndex = laneIndex;

        Camera.transform.DOMoveZ(-50 + 80 * laneIndex, duration);

        var z = 80f * laneIndex;
        for (int i = laneIndex; i < Lanes.Length; i++)
        {
            Lanes[i].transform.DOScale(Mathf.Pow(.8f, i - laneIndex), duration);
            Lanes[i].transform.DOMoveZ(z, duration);
            z += Mathf.Pow(.8f, i - laneIndex + 1) * 100;
        }
        
    }
}
