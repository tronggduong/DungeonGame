using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = GameManager.instance.player.maxHitPoint;
        slider.value = GameManager.instance.player.hitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = GameManager.instance.player.maxHitPoint;
        slider.value = GameManager.instance.player.hitPoint;
        /* get the color corresponding to player's health
         * normalize to get the value between (0,1) corresponding to gradient
         */
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
