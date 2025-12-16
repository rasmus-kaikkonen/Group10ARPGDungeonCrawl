using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(float val)
    {
        slider.maxValue = val;
        slider.value = val;
    }

    public void SetValue(float val)
    {
        slider.value = val;
    }
}
