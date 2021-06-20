using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Health health;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        if (health != null)
        {
            slider.maxValue = health.startingHP;
            slider.value = health.startingHP;
            UpdateSlider();
        }
    }

    public void ChangeValue(float value)
    {
        slider.value += value;
        UpdateSlider();
    }

    public void UpdateValue()
    {
        Debug.Log("Updating slider");
        slider.value = health.GetCurrentHealth();
        UpdateSlider();
    }

    void UpdateSlider()
    {
        fill.color = gradient.Evaluate(1 / ((slider.maxValue - slider.minValue) / slider.value));
    }
}