using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace BattleCalc
{
  public class BattleManager : MonoBehaviour
  {
    public void StartBattle(Hero hero, Quest.Difficulty difficulty)
    {
      int heroRoll = CalculateHeroRoll(hero);
      //these values were determined arbitrarily according to average rolls and hero goldinventory potential
      int enemyRoll = 0;
      switch (difficulty)
      {
        case Quest.Difficulty.Easy:
          enemyRoll = CalculateEnemyRoll(1);
          break;
        case Quest.Difficulty.Medium:
          enemyRoll = CalculateEnemyRoll(1, 6, 1);
          break;
        case Quest.Difficulty.Hard:
          enemyRoll = CalculateEnemyRoll(2, 10, 6);
          break;
        case Quest.Difficulty.Insane:
          enemyRoll = CalculateEnemyRoll(1, 12, 6);
          break;
        default:
          Debug.LogError("Invalid difficulty selected.");
          return;
      }

      // Compare heroRoll and enemyRoll to determine success or failure
      if (heroRoll >= enemyRoll)
      {
        Debug.Log("Battle won!");
        // Perform actions for winning the battle, this would include sprit animations? 
        // figure we can do a victory animation, loss animation, and a battle animation that's extended? 
        // that might be what I work on next
      }
      else
      {
        Debug.Log("Battle lost!");
        // Perform actions for losing the battle
      }
    }
    public void StartBossBattle(Hero hero, Quest.Difficulty difficulty)
    {
      //these values were determined arbitrarily according to average rolls
      int heroRoll = CalculateHeroRoll(hero);
      int bossRoll = 0;
      int enemyRoll = 0;
      switch (difficulty)
      {
        case Quest.Difficulty.Easy:
          enemyRoll = CalculateEnemyRoll(1, 2, 0);
          break;
        case Quest.Difficulty.Medium:
          enemyRoll = CalculateEnemyRoll(2, 8, 4);
          break;
        case Quest.Difficulty.Hard:
          enemyRoll = CalculateEnemyRoll(1, 12, 8);
          break;
        case Quest.Difficulty.Insane:
          enemyRoll = CalculateEnemyRoll(1, 10, 6);
          break;
        case Quest.Difficulty.Final:
          enemyRoll = CalculateFinalBossRoll(3, 20, 7);
          break;
        default:
          Debug.LogError("Invalid difficulty selected.");
          return;
      }

      // Compare heroRoll and enemyRoll to determine success or failure
      if (heroRoll >= bossRoll)
      {
        Debug.Log("Boss Battle won!");
        // Perform actions for winning the battle, this would include sprit animations? 
      }
      else
      {
        Debug.Log("Boss Battle lost!");
        // Perform actions for losing the battle
      }
    }

    private int CalculateHeroRoll(Hero hero)
    {
      int level = hero.Level;
      int gold = hero.GoldInventory;

      int sides = 4 + ((level - 1) * 2); // Calculate the number of sides on the dice
      int roll = Mathf.CeilToInt((level + (gold / 100f)) * 0.5f); // Perform the roll and round up

      return roll;
    }

    private int CalculateEnemyRoll(int baseStrength)
    {
      return baseStrength;
    }

    private int CalculateEnemyRoll(int baseStrength, int diceSides, int bonus)
    {
      int roll = Random.Range(1, diceSides + 1); // Roll the dice
      return baseStrength + roll + bonus;
    }
    private int CalculateFinalBossRoll(int baseStrength, int diceSides, int bonus)
    {
      int roll = Random.Range(1, diceSides + 1); // Roll the dice
      int roll2 = Random.Range(1, diceSides + 1);
      int roll3 = Random.Range(1, diceSides + 1);
      return baseStrength + roll + roll2 + roll3 + bonus;
    }
  }
}
