using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySprite : MonoBehaviour
{
  private void Awake()
  {
    Destroy(this.gameObject, 3f);
  }
}
