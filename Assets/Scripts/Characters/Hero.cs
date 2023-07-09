using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Characters
{
  public abstract class Hero : Character
  {
    public int GoldInventory { get; set; }
    public string Class { get; set; }
    public int Cost
    {
      get
      {
        return 200 * Level;
      }
    }

    public Hero(int gold, string heroClass) : base("HeroDefault", 1)
    {
      GoldInventory = gold;
      Class = heroClass;
    }
  }
}