using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GainMoneyPerSecond : MonoBehaviour
{
  public System.DateTime dateTime;
  public System.DateTime lastTime;
  public Text moneygainwhileaway;
  public Text wishesgainwhileaway;
  public bool inMouseDown = false;
  public bool repeating = false;
  private void Awake()
  {
    if (PlayerPrefs.HasKey("Money") && PlayerPrefs.HasKey("Wishes") && PlayerPrefs.HasKey("MPS") && PlayerPrefs.HasKey("WPS"))
    {
      ResourceTracker.instance.Money += PlayerPrefs.GetFloat("Money");
      ResourceTracker.instance.Wishes += PlayerPrefs.GetFloat("Wishes");
      ResourceTracker.instance.wishesPerSecond += PlayerPrefs.GetFloat("WPS");
      ResourceTracker.instance.GainPerSecond += PlayerPrefs.GetFloat("MPS");
    }
    else
    {
      ResourceTracker.instance.Money = 0f;
      ResourceTracker.instance.Wishes = 0f;
      ResourceTracker.instance.wishesPerSecond = 0f;
      ResourceTracker.instance.GainPerSecond = 0f;
    }
    if (PlayerPrefs.HasKey("UMP") && PlayerPrefs.HasKey("UWP")) 
    {
      ResourceTracker.instance.upgradeMPScost = PlayerPrefs.GetFloat("UMP");
      ResourceTracker.instance.upgradeWPScost = PlayerPrefs.GetFloat("UWP");
    }
    
    if (PlayerPrefs.HasKey("CurrentMoney"))
    {
      if (PlayerPrefs.GetString("CurrentMoney") == "Penny")
      {
        ResourceTracker.instance.currentMoney = ResourceTracker.instance.coins[0];
      }
      else if (PlayerPrefs.GetString("CurrentMoney") == "Nickel")
      {
        ResourceTracker.instance.currentMoney = ResourceTracker.instance.coins[1];
      }
      else if (PlayerPrefs.GetString("CurrentMoney") == "Silver")
      {
        ResourceTracker.instance.currentMoney = ResourceTracker.instance.coins[2];
      }
      else if (PlayerPrefs.GetString("CurrentMoney") == "GoldCoin")
      {
        ResourceTracker.instance.currentMoney = ResourceTracker.instance.coins[3];
      }
      else if (PlayerPrefs.GetString("CurrentMoney") == "Crypto")
      {
        ResourceTracker.instance.currentMoney = ResourceTracker.instance.coins[4];
      }
      else if (PlayerPrefs.GetString("CurrentMoney") == "Uranium")
      {
        ResourceTracker.instance.currentMoney = ResourceTracker.instance.coins[5];
      }
    }
    if (PlayerPrefs.HasKey("ShouldEarn"))
    {
      if (PlayerPrefs.GetInt("ShouldEarn") == 1)
      {
        ShouldEarnPerSec = true;
      }
      else if (PlayerPrefs.GetInt("ShouldEarn") == 0)
      {
        ShouldEarnPerSec = false;
      }
    }
    
    if (PlayerPrefs.HasKey("Date")) 
    {
      string dateString = PlayerPrefs.GetString("Date");
      lastTime = System.DateTime.Parse(dateString);
      System.DateTime comparetime = System.DateTime.Now;
      System.TimeSpan span = comparetime - lastTime;

      float moneyToAdd = (float)span.TotalSeconds * PlayerPrefs.GetFloat("MPS");
      float wishesToadd = (float)span.TotalSeconds * PlayerPrefs.GetFloat("WPS");
      ResourceTracker.instance.Money += moneyToAdd;
      ResourceTracker.instance.Wishes += wishesToadd ;
      moneygainwhileaway.text = moneyToAdd.ToString();
      wishesgainwhileaway.text = wishesToadd.ToString();
    }
    if (PlayerPrefs.HasKey("Resets")) 
    {
      ResourceTracker.instance.resets = PlayerPrefs.GetFloat("Resets");
    }
    
  }
  private bool ShouldEarnPerSec;
  private void OnMouseDown()
  {

    inMouseDown = true;
      
    
  }
  private void OnMouseUp()
  {

    inMouseDown = false;
  }
  
  private void FixedUpdate()
  {
    
    if (ShouldEarnPerSec == true) 
    {
      ResourceTracker.instance.GainMoneyPerSecAndWishes();
    }
  }
  private void Update()
  {
    if (inMouseDown == true && !repeating)
    {
      InvokeRepeating("gainMoneyAndWishes", 0.1f, 1f);

    }
    else
    {
      repeating = false;
      CancelInvoke("gainMoneyAndWishes");
    }
  }
  public void gainMoneyAndWishes() 
  {
    repeating = true;
    ResourceTracker.instance.Money += ResourceTracker.instance.currentMoney.amountToIncreamentMoney / 60f;
    ResourceTracker.instance.Wishes += ResourceTracker.instance.currentMoney.amountToIncreamentWishes / 60f;
  }
  
  private void OnApplicationQuit()
  {
    PlayerPrefs.SetFloat("Resets", ResourceTracker.instance.resets);
    PlayerPrefs.SetString("Date", System.DateTime.Now.ToString());
    PlayerPrefs.SetFloat("Money", ResourceTracker.instance.Money);
    PlayerPrefs.SetFloat("Wishes", ResourceTracker.instance.Wishes);
    PlayerPrefs.SetFloat("MPS", ResourceTracker.instance.GainPerSecond);
    PlayerPrefs.SetFloat("WPS", ResourceTracker.instance.wishesPerSecond);
    PlayerPrefs.SetString("CurrentMoney", ResourceTracker.instance.currentMoney.name);
    if (ShouldEarnPerSec == true)
    {
      PlayerPrefs.SetInt("ShouldEarn", 1);
    }
    else if (ShouldEarnPerSec == false) 
    {
      PlayerPrefs.SetInt("ShouldEarn", 0);
    }
    PlayerPrefs.SetFloat("UMP", ResourceTracker.instance.upgradeMPScost);
    PlayerPrefs.SetFloat("UWP", ResourceTracker.instance.upgradeWPScost);
  }
  public void StartPassiveGain() 
  {
    if (ShouldEarnPerSec == false)
    {
      ShouldEarnPerSec = true;
    }
  }
 
  


}
