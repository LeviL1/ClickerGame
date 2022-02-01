using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMoneyTxt : MonoBehaviour
{
    public Text MoneyTxt;
    public Text WishesText;
    public ResourceTracker tracker;
    
    public void updateMoneyAndWishes()
    {
        float moneyToAdd = tracker.Money;
        MoneyTxt.text = moneyToAdd.ToString();
        float wishesToAdd = tracker.Wishes;
        WishesText.text = wishesToAdd.ToString();
        
    }
  private void Update()
  {
    updateMoneyAndWishes();
  }

}
