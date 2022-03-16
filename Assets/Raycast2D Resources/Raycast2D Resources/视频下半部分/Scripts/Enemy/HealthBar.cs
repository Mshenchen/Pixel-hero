using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public float maxHp = 100f;
    public float currentHp = 10f;
    public float hurtSpeed = 0.03f;
    public Image healthPointImage;
    public Image healthPointEffect;
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        healthPointImage.fillAmount = currentHp / maxHp;
        if (healthPointImage.fillAmount < healthPointEffect.fillAmount)
        {
            healthPointEffect.fillAmount -= hurtSpeed;
        }
        else
        {
            healthPointEffect.fillAmount = healthPointImage.fillAmount;
        }
    }
}
