using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward
{

  public int Exp { get; set; }
  public int Gold { get; set; }
  public int Corruption { get; set; }

  public Reward(Quest.Difficulty diff, Quest.Theme theme)
  {
    switch (theme)
    {
      case Quest.Theme.Simple:
        Exp = DiceRoller.Roll(1, 5) * ((int)diff + 1);
        Gold = DiceRoller.Roll(100, 300) * ((int)diff + 1);
        Corruption = DiceRoller.Roll(0, 1) * ((int)diff + 1);
        break;
      case Quest.Theme.Slay:
        Exp = DiceRoller.Roll(1, 5) * ((int)diff + 1);
        Gold = DiceRoller.Roll(100, 300) * ((int)diff + 1);
        Corruption = DiceRoller.Roll(0, 1) * ((int)diff + 1);
        break;
      case Quest.Theme.Save:
        Exp = DiceRoller.Roll(1, 5) * ((int)diff + 1);
        Gold = DiceRoller.Roll(100, 300) * ((int)diff + 1);
        Corruption = DiceRoller.Roll(0, 1) * ((int)diff + 1);
        break;
      case Quest.Theme.Steal:
        Exp = DiceRoller.Roll(1, 5) * ((int)diff + 1);
        Gold = DiceRoller.Roll(100, 300) * ((int)diff + 1);
        Corruption = DiceRoller.Roll(0, 1) * ((int)diff + 1);
        break;
      default:
        Exp = DiceRoller.Roll(1, 5) * ((int)diff + 1);
        Gold = DiceRoller.Roll(100, 300) * ((int)diff + 1);
        Corruption = DiceRoller.Roll(0, 1) * ((int)diff + 1);
        break;
    }
  }

  public Reward(int exp, int gold, int corruption)
  {
    Exp = exp;
    Gold = gold;
    Corruption = corruption;
  }
}
