using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatText 
{
    public bool check;
    public GameObject go;
    public Text text;
    public Vector3 motion;
    public float duration;
    public float lastShown;
    
    public void Show()
    {
        check = true;
        lastShown = Time.time;
        go.SetActive(check);
    }
    public void Hidden()
    {
        check = false;
        go.SetActive(check);
    }
    public void UpdateText()
    {
        if (check)
        {
            if(Time.time - lastShown > duration)
            {
                Hidden();
            }
            else
            {
                go.transform.position += motion * Time.deltaTime;
            }
        }
        else return;
    }
}
