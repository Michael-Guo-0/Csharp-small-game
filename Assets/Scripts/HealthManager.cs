using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public Color Low;
    public Color High;
    public Vector3 offset;
    public Image fillImage;
    

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        if(health <= 0)
        {
            slider.gameObject.SetActive(false);
        }
        float fillValue = health / maxHealth;
        /*
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;*/

        slider.value = fillValue;
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.value);
    }

}
