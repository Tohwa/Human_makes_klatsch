using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    private TextMeshProUGUI textComp;

    // Start is called before the first frame update
    void Awake()
    {
        textComp = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        Slider slider = GetComponentInParent<Slider>();
        UpdateText(slider.value);
        slider.onValueChanged.AddListener(UpdateText);
    }

    void UpdateText(float value)
    {
        int brrbr = (int)(value * 100);
        textComp.text = brrbr.ToString();
    }
}
