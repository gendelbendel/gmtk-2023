using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{

  public enum HeroClassName
  {
    Barbarian,
    Rogue,
    Cleric,
    Knight,
    Blacksmith,
    Wizard,
    Ranger
  }

  // Barbs hit hard
  // but HP doesnt increase as much
  public class Barbarian : Hero
  {
    public Barbarian(string name = "James") : base(100, "Barbarian")
    {
      Debug.Log(Class);
      HPPerLevel = 4;
      BaseHP = 13;
      HP = BaseHP;

      BaseAttack = 14;
      AttackPerLevel = 8;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/waraxe";
      CharacterSpriteName = "Characters/Heroes/barbarian";
      ClassIconSpriteName = WeaponSpriteName;

      LoadAllSprites();
    }

  }

  // Rogues swing twice per attack
  // but are squishier
  public class Rogue : Hero
  {
    public Rogue(string name = "Joobus") : base(100, "Rogue")
    {
      Debug.Log(Class);
      HPPerLevel = 3;
      BaseHP = 10;
      HP = BaseHP;

      BaseAttack = 7;
      AttackPerLevel = 4;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/knife";
      CharacterSpriteName = "Characters/Heroes/rogue";
      ClassIconSpriteName = WeaponSpriteName;

      LoadAllSprites();
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
      Name = DiceRoller.GenerateName(false);
      Debug.Log(Class);
      HPPerLevel = 4;
      BaseHP = 10;
      HP = BaseHP;

      BaseAttack = 4;
      AttackPerLevel = 2;

      AttackSpeed = 0.5f;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/cleric_staff";
      CharacterSpriteName = "Characters/Heroes/cleric";
      ClassIconSpriteName = WeaponSpriteName;

      LoadAllSprites();
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
      Name = DiceRoller.GenerateName(false);
      Debug.Log(Class);
      HPPerLevel = 10;
      BaseHP = 18;
      HP = BaseHP;

      BaseAttack = 8;
      AttackPerLevel = 2;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/sword";
      ShieldSpriteName = "Equipment/Shields/kite";
      CharacterSpriteName = "Characters/Heroes/knight";
      ClassIconSpriteName = ShieldSpriteName;

      LoadAllSprites();
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
      Debug.Log(Class);
      HPPerLevel = 10;
      BaseHP = 18;
      HP = BaseHP;

      BaseAttack = 8;
      AttackPerLevel = 2;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/hammer";
      CharacterSpriteName = "Characters/Heroes/blacksmith";
      ClassIconSpriteName = WeaponSpriteName;

      LoadAllSprites();
    }
  }

  // Wizards hit hard, but slowly
  // and take more damage
  public class Wizard : Hero
  {
    public Wizard(string name = "Jeddddd") : base(100, "Wizard")
    {
      Debug.Log(Class);
      HPPerLevel = 2;
      BaseHP = 10;
      HP = BaseHP;

      BaseAttack = 20;
      AttackPerLevel = 10;

      AttackSpeed = 0.5f;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/wizard_staff";
      CharacterSpriteName = "Characters/Heroes/wizard";
      ClassIconSpriteName = WeaponSpriteName;

      LoadAllSprites();
    }
  }

  // Rangers have a chance to avoid attacks
  public class Ranger : Hero
  {
    public Ranger(string name = "Jake") : base(100, "Ranger")
    {
      Debug.Log(Class);

      HPPerLevel = 5;
      BaseHP = 14;
      HP = BaseHP;

      BaseAttack = 12;
      AttackPerLevel = 6;

      // TODO: Get sprite names for weapon and class
      WeaponSpriteName = "Equipment/Weapons/bow";
      CharacterSpriteName = "Characters/Heroes/ranger";
      ClassIconSpriteName = WeaponSpriteName;

      LoadAllSprites();
    }

    // Rangers can avoid damage sometimes
    public override void ReceiveAttack(int damage)
    {
      // TODO: RNG avoid damage
      HP -= damage;
    }
  }
}

