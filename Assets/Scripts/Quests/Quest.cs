using System;
using System.Collections;
using System.Collections.Generic;

public class Quest
{
  public enum Difficulty
  {
    Easy,
    Medium,
    Hard,
    Insane
  }

  public enum Theme
  {
    Simple,
    Slay,
    Steal,
    Save
  }

  private Difficulty _difficulty;
  private int _partySize = 1;
  private Theme _theme;
  private int _objectiveQuantity;
  private int _objectiveStringIndex;
  private int _currentObjectiveProgress;

  private List<Reward> _rewards;

  private string[] _simpleObjects = new string[] {
    "mushroom",
    "",
    "",
  };

  private string[] _slayObjects = new string[] {
    "goblin",
    "imp",
    "bat",
    "skeleton",
    ""
  };

  private string[] _stealObjects = new string[] {
    "Mystical Artifact",
    "gold coin",
    "",
  };

  private string[] _saveObjects = new string[] {
    "princess",
    "alchemist",
    "child",
    "peasant",
    ""
  };

  public Quest()
  {
    _difficulty = Difficulty.Easy;
    _partySize = (int)_difficulty + 1;
    _theme = GetRandomTheme();
    GenerateRewards();
  }

  public Quest(Difficulty difficulty)
  {
    _difficulty = difficulty;
    _partySize = (int)_difficulty + 1;
    _theme = GetRandomTheme();
    GenerateRewards();
  }

  public Quest(Difficulty difficulty, Theme theme)
  {
    _difficulty = difficulty;
    _partySize = (int)_difficulty + 1;
    _theme = theme;
    GenerateRewards();
  }

  public Theme GetRandomTheme()
  {
    return (Theme)new System.Random().Next(0, Enum.GetValues(typeof(Theme)).Length);
  }

  public void GenerateRewards()
  {

  }

}
