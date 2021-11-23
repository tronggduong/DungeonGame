using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefabs;

    private List<FloatText> floatTexts = new List<FloatText>();

    public void Show(string message,int fontSize,Color color,Vector3 position,Vector3 motion,float duration)
    {
        FloatText txt = GetFloatText();
        txt.text.text = message;
        txt.text.fontSize = fontSize;
        txt.text.color = color;
        //Have to change because pixels is different in UI
        txt.go.transform.position = Camera.main.WorldToScreenPoint(position);
        txt.motion = motion;
        txt.duration = duration;

        txt.Show();
    }
    private FloatText GetFloatText()
    {
        FloatText text = floatTexts.Find(t => !t.check);
        if (text == null)
        {
            text = new FloatText
            {
                go = Instantiate(textPrefabs)
            };
            text.go.transform.SetParent(textContainer.transform);
            text.text = text.go.GetComponent<Text>();
            floatTexts.Add(text);
        }

        return text;
    }
    private void Update()
    {
        foreach(FloatText txt in floatTexts)
        {
            txt.UpdateText();
        }
    }
}
