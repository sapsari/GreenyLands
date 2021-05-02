using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : MonoBehaviour
{
    public Text TextTop;
    public Text TextButton;

    System.Action del;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(string description, string button, System.Action del = null)
    {
        TextTop.text = description;
        TextButton.text = button;
        this.del = del;
        this.gameObject.SetActive(true);
    }

    public void OnClick()
    {
        this.gameObject.SetActive(false);
        del?.Invoke();
    }
}
