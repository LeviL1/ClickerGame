using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Money", menuName = "ScriptableObjects/Money", order = 1)]
public class Money : ScriptableObject
{
    [SerializeField]
    public float amountToIncreamentMoney;
    [SerializeField]
    public float amountToIncreamentWishes;
    [SerializeField]
    public Sprite coinImage;
  public float upgradeCost;
  public Money nextTier;
}
