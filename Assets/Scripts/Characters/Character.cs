using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
  public abstract class Character
  {
    public string Name { get; set; } = "CharacterDefault";
    public int Level { get; set; }
    public int Status { get; set; } = 0;


    // Weapon sprite
    public string WeaponSpriteName { get; set; } = "";
    public bool HasWeapon
    {
      get
      {
        return WeaponSpriteName.Length > 0 ? true : false;
      }
    }
    public Sprite WeaponSprite { get; set; }

    // Shield sprite
    public string ShieldSpriteName { get; set; } = "";
    public bool HasShield
    {
      get
      {
        return ShieldSpriteName.Length > 0 ? true : false;
      }
    }
    public Sprite ShieldSprite { get; set; }

    // Sprite
    public string CharacterSpriteName { get; set; } = "";
    public Sprite CharacterSprite { get; set; }
    public bool HasCharacter
    {
      get
      {
        return CharacterSpriteName.Length > 0 ? true : false;
      }
    }

    public int HP { get; set; }
    public int BaseHP { get; set; } = 10;
    public int HPPerLevel { get; set; } = 5;
    public int MaxHP
    {
      get
      {
        return BaseHP + (HPPerLevel * (Level - 1));
      }
    }

    public int BaseAttack { get; set; } = 10;
    public int AttackPerLevel { get; set; } = 5;
    public int Attack
    {
      get
      {
        return BaseAttack + (AttackPerLevel * (Level - 1));
      }
    }

    public int XP { get; set; } = 0;
    public int BaseXPRequired { get; set; } = 1;
    public int XPRequired
    {
      get
      {
        return BaseXPRequired + (1 * Level);
      }
    }

    public float AttackSpeed { get; set; } = 1.0f;

    public Character(string name, int level)
    {
      Name = name;
      Level = level;
    }

    public Character(int level)
    {
      Name = DiceRoller.GenerateName(true);
      Level = level;
    }

    public virtual void PerformAttack(Character character)
    {
      character.ReceiveAttack(Attack);
    }

    public virtual void ReceiveAttack(int damage)
    {
      HP -= damage;
    }

    public virtual bool ShouldDie()
    {
      if (HP <= 0)
      {
        return true;
      }
      return false;
    }

    public virtual void Die()
    {
      //die
    }

    // Increase level, heal to full
    public void LevelUp()
    {
      Level++;
      HP = MaxHP;
    }

    public int RemainingExp()
    {
      // if (XP >= XPRequired) {
      //   LevelUp();
      // }
      return XPRequired - XP;
    }

    public void GainXP(int amt)
    {
      XP += amt;
    }

    public void LoadCharacterSprite()
    {
      if (HasCharacter)
      {
        CharacterSprite = ResourceLoader.LoadResource<Sprite>(CharacterSpriteName);
      }
      else
      {
        Debug.Log("No Character");
      }
    }

    public void LoadWeaponSprite()
    {
      if (HasWeapon)
      {
        WeaponSprite = ResourceLoader.LoadResource<Sprite>(WeaponSpriteName);
      }
      else
      {
        Debug.Log("No Weapon");
      }
    }

    public void LoadShieldSprite()
    {
      if (HasShield)
      {
        ShieldSprite = ResourceLoader.LoadResource<Sprite>(ShieldSpriteName);
      }
      else
      {
        Debug.Log("No Shield");
      }
    }

  }
}