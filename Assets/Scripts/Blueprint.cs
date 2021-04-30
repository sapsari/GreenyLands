using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blueprint : MonoBehaviour
{
    public ZoneKind Kind;

    BlueprintManager manager;

    public void Start()
    {
        manager = FindObjectOfType<BlueprintManager>();
    }

    public void OnSelect()
    {
        manager.OnSelect(this);
    }
}
