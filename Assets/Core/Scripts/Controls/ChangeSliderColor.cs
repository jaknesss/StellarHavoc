using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderFillColor : MonoBehaviour
{
    public Slider slider;     // Prende l'oggetto slider da modificare
    public Image fillImage;   // Prende una delle immagini dello slider da modificare

    public Color minColor;    // Colore presente qunado slider è al minimo 
    public Color maxColor;    // Colore presente qunado slider è al massimo

    private void Update()
    {
        float sliderValue = slider.value;

        // Normalizza il valore dello slider tra 0 e 1
        float normalizedValue = Mathf.InverseLerp(slider.minValue, slider.maxValue, sliderValue);

        // Interpola tra i colori in base al valore normalizzato
        fillImage.color = Color.Lerp(minColor, maxColor, normalizedValue);
    }
}
