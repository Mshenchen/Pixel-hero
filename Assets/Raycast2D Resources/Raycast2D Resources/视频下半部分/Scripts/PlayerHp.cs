using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{
    public float playerHp = 100f;
    public float playercurrentHp = 10f;
    public Image playerHpImage;
    public Image playerHpEffect;
    public float playerHurtSpeed;
    void Start()
    {
        playercurrentHp = playerHp;
    }

    // Update is called once per frame
    void Update()
    {
        playerHpImage.fillAmount = playercurrentHp / playerHp;
        if (playerHpImage.fillAmount < playerHpEffect.fillAmount)
        {
            playerHpEffect.fillAmount -= playerHurtSpeed;
        }
        else
        {
            playerHpEffect.fillAmount = playerHpImage.fillAmount;
        }
    }
}
