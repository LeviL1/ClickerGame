using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GainMoneyPerSecond : MonoBehaviour
{

  public float fireRate;
  
  bool isPressed = false;

  private void OnMouseDown()
  {
    isPressed = true;
   
  }
  private void FixedUpdate()
  {
    if (isPressed)
    {
      ResourceTracker.instance.GainMoneyPerSecAndWishes();
    }
  }
  private void OnMouseUp()
  {
    isPressed = false;
  }
}
