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

    public string ClassIconSpriteName { get; set; } = "";
    public Sprite ClassIconSprite;
    public bool HasClassIcon
    {
      get
      {
        return ClassIconSpriteName.Length > 0 ? true : false;
      }
    }

    public Hero(int gold, string heroClass) : base(1)
    {
      GoldInventory = gold;
      Class = heroClass;
    }

    public void LoadClassIconSprite()
    {
      if (HasClassIcon)
      {
        ClassIconSprite = ResourceLoader.LoadResource<Sprite>(ClassIconSpriteName);
      }
      else
      {
        Debug.Log("No ClassIcon");
      }
    }

    public void LoadAllSprites()
    {
      LoadClassIconSprite();
      LoadShieldSprite();
      LoadWeaponSprite();
      LoadCharacterSprite();
    }
  }
}