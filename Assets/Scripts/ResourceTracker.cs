using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourceTracker : MonoBehaviour
{
  //values for resources 
  public float Wishes, Money;
  public float GainPerSecond;
  public float wishesPerSecond;
  public Money currentMoney;
  public float AmountToIncreamentMoney;
  public float AmountToIncreamentWishes;

  public Animator fountainAnim;
  public List<Money> coins = new List<Money>();

  public Text upgradeCost;
  public Text MPSupgrade;
  public Text WPSupgrade;
  public float upgradeMPScost;
  public float upgradeWPScost;
  public static ResourceTracker instance;
  public Image CurrentCoin;
  public Button resetButton;

  private void Awake()
  {
    
    if (ResourceTracker.instance == null)
    {
      ResourceTracker.instance = this;
    }
    else if (ResourceTracker.instance != this)
    {
      Destroy(this);
    }

  }
  private void Start()
  {
    resetButton.enabled = false;
  }

  private void Update()
  {
    CurrentCoin.sprite = currentMoney.coinImage;
    MPSupgrade.text = upgradeMPScost.ToString();
    WPSupgrade.text = upgradeWPScost.ToString();
    if (currentMoney.name == "Penny")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
    }
    else if (currentMoney.name == "Nickel")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
    }
    else if (currentMoney.name == "Silver")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
    }

    else if (currentMoney.name == "GoldCoin")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
    }
    else if (currentMoney.name == "Crypto")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
    }
    else if (currentMoney.name == "Uranium")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
      resetButton.enabled = true;
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
  public void GainMoneyPerSecAndWishes()
  {
    Money += GainPerSecond;
    Wishes += wishesPerSecond;
  }

  public void ChangeCurrency()
  {
    if (Money >= currentMoney.upgradeCost)
    {
      Money -= currentMoney.upgradeCost;
      currentMoney = currentMoney.nextTier;
    }
  }
  public void upgradeMPS()
  {
    if (Money >= upgradeMPScost && upgradeMPScost == 100)
    {
      Money -= upgradeMPScost;
      GainPerSecond += 10f;
      upgradeMPScost = 500;
    }
    if (Money >= upgradeMPScost && upgradeMPScost == 1000)
    {
      Money -= upgradeMPScost;
      GainPerSecond += 30f;
      upgradeMPScost = 1000;
    }

  }
  public void upgradeWPS()
  {
    if (Wishes >= upgradeWPScost && upgradeWPScost == 100)
    {
      Wishes -= upgradeWPScost;
      wishesPerSecond += 5f;
      upgradeWPScost = 250;
    }
    if (Wishes >= upgradeWPScost && upgradeWPScost == 1000)
    {
      Wishes -= upgradeWPScost;
      GainPerSecond += 20f;
      upgradeMPScost = 1000;
    }
  }
  public void QuitGame() 
  {
    Application.Quit();
  }
}
