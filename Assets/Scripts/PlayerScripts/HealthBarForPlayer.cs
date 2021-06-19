using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarForPlayer : MonoBehaviour
{
    public Image healthBar;
    public Text healthBarText;
    private void Awake()
    {
        healthBarText = GetComponent<Text>();
        //healthBarText.text = "";
    }
    public void SetUIHealth(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
        //healthBarText.text = (int)health + "/" + (int)maxHealth;
        //Debug.Log("current health: " + health);
        //Debug.Log("max health: " + maxHealth);
        //Debug.Log(healthText);
        //Debug.Log(healthBar.fillAmount);
    }
}
