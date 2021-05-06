using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(TextMeshProUGUI))]
public class SliderText : MonoBehaviour
{
    public Slider slider;

    private TextMeshProUGUI sliderText;

    private void OnEnable()
    {
        sliderText = GetComponent<TextMeshProUGUI>();
    }

    public void SetText()
    {
        if (!sliderText) return;
        if (!slider) return;
        sliderText.text = slider.value.ToString();
    }
}
