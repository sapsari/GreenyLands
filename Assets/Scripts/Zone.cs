using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneKind { Village, Town, City, Forest, Field, Hills }

public class Zone : MonoBehaviour
{
    public string Name;
    public ZoneKind Kind;
    public Prefabs Prefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construct(Blueprint bp)
    {
        if (transform.childCount > 0)
        {
            var child = transform.GetChild(0);
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }

        var prefab = Prefabs.GetInstanceOf(bp.Kind);
        prefab.transform.parent = transform;
        prefab.transform.localScale = Vector3.one;
    }
}
