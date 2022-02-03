using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSprites : MonoBehaviour
{
  public GameObject Penny, Nickel, Silver, Gold, Cryto, Uranium;
  public GameObject objectToSpawn;
  public Transform[] spawnPoints;
  private void Update()
  {
    if (ResourceTracker.instance.currentMoney.name == "Penny")
    {
      objectToSpawn = Penny;
    }
    else if (ResourceTracker.instance.currentMoney.name == "Nickel") 
    {
      objectToSpawn = Nickel;
    }
    else if (ResourceTracker.instance.currentMoney.name == "Silver")
    {
      objectToSpawn = Silver;
    }
    else if (ResourceTracker.instance.currentMoney.name == "GoldCoin")
    {
      objectToSpawn = Gold;
    }
    else if (ResourceTracker.instance.currentMoney.name == "Crypto")
    {
      objectToSpawn = Cryto;
    }
    else if (ResourceTracker.instance.currentMoney.name == "Uranium")
    {
      objectToSpawn = Uranium;
    }
  }

  public void SpawnObject() 
  {
    Instantiate(objectToSpawn, spawnPoints[Random.Range(0, 5)]);
  }
}
