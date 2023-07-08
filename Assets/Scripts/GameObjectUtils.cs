using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameObjectUtils
{
  public static GameObject GetActiveAndInactiveGameobjectByName(string name)
  {
    return GameObject.FindObjectsOfType<GameObject>(true).Where(sr => sr.gameObject.name == name).ToArray()[0];
  }
}
