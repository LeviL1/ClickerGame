using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GainMoneyPerSecond : MonoBehaviour
{
  public System.DateTime dateTime;
  public System.DateTime lastTime;
  public Text timeSinceOpened;
  private void Awake()
  {
    dateTime = System.DateTime.Now;
    if (PlayerPrefs.HasKey("Date")) 
    {
      string dateString = PlayerPrefs.GetString("Date");
      lastTime = System.DateTime.Parse(dateString);
      System.DateTime comparetime = System.DateTime.Now;
      System.TimeSpan span = comparetime - lastTime;

      float moneyToAdd = (float)span.TotalSeconds * ResourceTracker.instance.GainPerSecond;
      ResourceTracker.instance.Money += moneyToAdd;
    }
    if (PlayerPrefs.HasKey("Money") && PlayerPrefs.HasKey("Wishes") && PlayerPrefs.HasKey("MPS") && PlayerPrefs.HasKey("WPS"))
    {
      ResourceTracker.instance.Money += PlayerPrefs.GetFloat("Money");
      ResourceTracker.instance.Wishes += PlayerPrefs.GetFloat("Wishes");
      ResourceTracker.instance.wishesPerSecond += PlayerPrefs.GetFloat("WPS");
      ResourceTracker.instance.GainPerSecond += PlayerPrefs.GetFloat("MPS");
    }
    else 
    {
      ResourceTracker.instance.Money += 0f;
      ResourceTracker.instance.Wishes += 0f;
      ResourceTracker.instance.wishesPerSecond += 0f;
      ResourceTracker.instance.GainPerSecond += 0f;
    }
  }
  private bool ShouldEarnPerSec = false;
 
  private void FixedUpdate()
  {
    if (ResourceTracker.instance.Money >= 100)
    {
      ShouldEarnPerSec = true;
      ResourceTracker.instance.GainMoneyPerSecAndWishes();
    }
    else if (ShouldEarnPerSec == true) 
    {
      ResourceTracker.instance.GainMoneyPerSecAndWishes();
    }
  }
  private void OnApplicationQuit()
  {
    PlayerPrefs.SetString("Date", System.DateTime.Now.ToString());
    PlayerPrefs.SetFloat("Money", ResourceTracker.instance.Money);
    PlayerPrefs.SetFloat("Wishes", ResourceTracker.instance.Wishes);
    PlayerPrefs.SetFloat("MPS", ResourceTracker.instance.GainPerSecond);
    PlayerPrefs.SetFloat("WPS", ResourceTracker.instance.wishesPerSecond);
  }
  

}
