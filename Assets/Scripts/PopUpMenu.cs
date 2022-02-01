using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUpMenu : MonoBehaviour
{
  public Canvas popUpMenu;
  private void Start()
  {
    popUpMenu.enabled = false;
  }
  public void setMenuToOpen() 
  {
    popUpMenu.enabled = true;
  }

  public void closePopUpMenu() 
  {
    popUpMenu.enabled = false;
  }
}
