using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiceRoller
{
  public static System.Random r = new System.Random();

  public static int Roll(int min, int max)
  {
    return r.Next(min, max);
  }

  public static int GetRandomObject<T>(T[] objects)
  {
    return Roll(0, objects.Length);
  }
}
