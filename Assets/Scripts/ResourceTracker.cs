using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
  public Canvas creditsImage;
  public AudioSource aud;
  public Canvas passiveGain;
  public float resets;
  public Text resetstxt;
  public TMP_Text MPS;
  public TMP_Text WPS;
  public TMP_Text MoneyValue;
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
    passiveGain.enabled = false;
    creditsImage.enabled = false;
    resetButton.enabled = false;
  }

  private void Update()
  {
    MoneyValue.text = currentMoney.amountToIncreamentMoney.ToString() + "$ Coin Value";
    WPS.text = wishesPerSecond.ToString();
    MPS.text = GainPerSecond.ToString();
    resetstxt.text = resets.ToString();
    CurrentCoin.sprite = currentMoney.coinImage;
    MPSupgrade.text = upgradeMPScost.ToString();
    WPSupgrade.text = upgradeWPScost.ToString();
    if (currentMoney.name == "Penny")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
      resetButton.enabled = false;
    }
    else if (currentMoney.name == "Nickel")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
      resetButton.enabled = false;
    }
    else if (currentMoney.name == "Silver")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
      resetButton.enabled = false;
    }

    else if (currentMoney.name == "GoldCoin")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
      resetButton.enabled = false;
    }
    else if (currentMoney.name == "Crypto")
    {
      AmountToIncreamentMoney = currentMoney.amountToIncreamentMoney;
      AmountToIncreamentWishes = currentMoney.amountToIncreamentWishes;
      upgradeCost.text = currentMoney.upgradeCost.ToString();
      resetButton.enabled = false;
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
    if (Money >= upgradeMPScost)
    {
      Money -= upgradeMPScost;
      GainPerSecond += 10f;
      upgradeMPScost *= 2.5f ;
    }
    

  }
  public void upgradeWPS()
  {
    if (Wishes >= upgradeWPScost)
    {
      Wishes -= upgradeWPScost;
      wishesPerSecond += 5f;
      upgradeWPScost *= 2.5f;

    }
  }
  public void QuitGame() 
  {
    Application.Quit();
  }
  public void ResetResources() 
  {
    resets += 1;
    Money = 0;
    Wishes = 0;
    currentMoney = coins[0];
    GainPerSecond *= 2f;
    wishesPerSecond *= 2f;
    upgradeWPScost = 100f;
    upgradeMPScost = 100f;

  }
  public void OpenCredits() 
  {
    
    creditsImage.enabled = true;
  }
  public void CloseCredits() 
  {
    
    creditsImage.enabled = false;
  }
  public void playAudioSource() 
  {
    aud.Play();
  }
  public void showGains() 
  {
    passiveGain.enabled = true;

  }
  public void hideGains()
  {
    passiveGain.enabled = false;
  }

}
