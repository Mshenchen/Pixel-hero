using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{
    public static PlayerHp instance;
    public float playerHp = 100f;
    public float playercurrentHp = 10f;
    public Image playerHpImage;
    public Image playerHpEffect;
    public float playerHurtSpeed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
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
