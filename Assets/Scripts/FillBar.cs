using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    private Image bar;
    private float currentValue;
    private float maxValue;
    
    private void Start() =>
        bar = GetComponent<Image>();

    private void Update() =>
        bar.fillAmount = currentValue / maxValue;

    public void SetMaxValue(float value)
    {
        maxValue = value;
        SetValue(value);
    }

    public void SetValue(float value) =>
        currentValue = value;
}
