using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTracker : MonoBehaviour
{
    //values for resources 
    public float Wishes, Money;
    public float GainPerSecond;
    public Money currentMoney;
    public float AmountToIncreamentMoney;
    public float AmountToIncreamentWishes;

    public Animator fountainAnim;
    public List<Money> coins = new List<Money>();

    public static ResourceTracker instance;
    public void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (currentMoney.name == "Penny")
        {
            AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
            AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
        }
        else if (currentMoney.name == "Nickel")
        {
            AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
            AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
        }
        else if (currentMoney.name == "GoldCoin")
        {
            AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
            AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
        }
        else if (currentMoney.name == "Crypto")
        {
            AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
            AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
        }

    }
    public void GainMoney() 
    {
        Money += AmountToIncreamentMoney;
    }
    public void GainWishes() 
    {
        Wishes += AmountToIncreamentWishes;
    }
    public void PlayFountainAnim() 
    {
       
            fountainAnim.Play("Fountain");
            
        
    }

}
