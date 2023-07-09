using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
  // Barbs hit hard
  // but HP doesnt increase as much
  public class Barbarian : Hero
  {
    public Barbarian(string name = "James") : base(100, "Barbarian")
    {
      Name = name;

      HPPerLevel = 4;
      BaseHP = 13;
      HP = BaseHP;

      BaseAttack = 14;
      AttackPerLevel = 8;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "AXE_SPRITE.png";
      CharacterSpriteName = "";
    }

  }

  // Rogues swing twice per attack
  // but are squishier
  public class Rogue : Hero
  {
    public Rogue(string name = "Jerry") : base(100, "Rogue")
    {
      Name = name;

      HPPerLevel = 3;
      BaseHP = 10;
      HP = BaseHP;

      BaseAttack = 7;
      AttackPerLevel = 4;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "KNIFE_SPRITE.png";
      CharacterSpriteName = "";
    }

    public override void PerformAttack(Character character)
    {
      character.ReceiveAttack(Attack);
      character.ReceiveAttack(Attack);
    }
  }

  // Clerics heal allies on attack,
  // but are squishy and don't hit hard
  public class Cleric : Hero
  {
    public Cleric(string name = "Janice") : base(100, "Cleric")
    {
      Name = name;

      HPPerLevel = 4;
      BaseHP = 10;
      HP = BaseHP;

      BaseAttack = 4;
      AttackPerLevel = 2;

      AttackSpeed = 0.5f;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "BLUESTAFF_SPRITE.png";
      CharacterSpriteName = "";
    }

    public override void PerformAttack(Character character)
    {
      character.ReceiveAttack(Attack);
      // get all allies, heal
      // ally.RecieveAttack(-1 * Level)
    }
  }

  // Knights take less damage than other heroes
  // and get more HP as levels
  // but don't hit as hard
  public class Knight : Hero
  {
    public Knight(string name = "Jake") : base(100, "Knight")
    {
      Name = name;

      HPPerLevel = 10;
      BaseHP = 18;
      HP = BaseHP;

      BaseAttack = 8;
      AttackPerLevel = 2;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "SWORD_SPRITE.png";
      ShieldSpriteName = "SHIELD_SPRITE.png";
      CharacterSpriteName = "";
    }

    // Knights take 1 less damage per level with each attack
    public override void ReceiveAttack(int damage)
    {
      HP -= damage - (1 * Level);
    }
  }

  // Blacksmiths do... idk
  public class Blacksmith : Hero
  {
    public Blacksmith(string name = "Jerry") : base(100, "Blacksmith")
    {
      Name = name;

      HPPerLevel = 10;
      BaseHP = 18;
      HP = BaseHP;

      BaseAttack = 8;
      AttackPerLevel = 2;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "HAMMER_SPRITE.png";
      CharacterSpriteName = "";
    }
  }

  // Wizards hit hard, but slowly
  // and take more damage
  public class Wizard : Hero
  {
    public Wizard(string name = "Jeddddd") : base(100, "Wizard")
    {
      Name = name;

      HPPerLevel = 2;
      BaseHP = 10;
      HP = BaseHP;

      BaseAttack = 20;
      AttackPerLevel = 10;

      AttackSpeed = 0.5f;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "PURPLESTAFF.png";
      CharacterSpriteName = "";
    }
  }

  // Rangers have a chance to avoid attacks
  public class Ranger : Hero
  {
    public Ranger(string name = "Jake") : base(100, "Ranger")
    {
      Name = name;

      HPPerLevel = 5;
      BaseHP = 14;
      HP = BaseHP;

      BaseAttack = 12;
      AttackPerLevel = 6;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "SWORD_SPRITE.png";
      ShieldSpriteName = "SHIELD_SPRITE.png";
      CharacterSpriteName = "";
    }

    // Knights take 1 less damage per level with each attack
    public override void ReceiveAttack(int damage)
    {
      HP -= damage - (1 * Level);
    }
  }
}

