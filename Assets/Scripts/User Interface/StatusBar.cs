using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(int val)
    {
        slider.maxValue = val;
        slider.value = val;
    }

    public void SetValue(int val)
    {
        slider.value = val;
    }
}
