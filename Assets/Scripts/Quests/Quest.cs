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
    Insane,
    Final
  }

  public enum Theme
  {
    Simple,
    Slay,
    Steal,
    Save
  }

  public enum Location
  {
    Town,
    Forest,
    Dungeon,
    Graveyard,
    BEBG
  }

  private System.Random r;

  private Difficulty _difficulty;
  private int _partySize = 1;
  private Theme _theme;
  private int _objectiveQuantity;
  private int _objectiveStringIndex;
  private int _currentObjectiveProgress;
  private Location _objectiveLocation;

  private Reward _reward;

  private string[] _simpleObjects = new string[] {
    "mushroom"
  };

  private Location[] _locationsSimple = new Location[] {
    Location.Town,
    Location.Forest
  };

  private string[] _slayObjects = new string[] {
    "tiny ghost",
    "cyclops",
    "crab",
    "bat",
    "ghost",
    "spider",
    "brown rat",
    "grey rat"
  };

  private Location[] _locationsSlay = new Location[] {
    Location.Forest,
    Location.Dungeon,
    Location.Graveyard
  };

  private string[] _stealObjects = new string[] {
    "Mystical Artifact",
    "gold coin"
  };

  private Location[] _locationsSteal = new Location[] {
    Location.Town,
    Location.Dungeon,
    Location.Graveyard
  };

  private string[] _saveObjects = new string[] {
    "princess",
    "alchemist",
    "child",
    "peasant"
  };

  private Location[] _locationsSave = new Location[] {
    Location.Forest,
    Location.Dungeon,
    Location.Graveyard
  };

  public Quest()
  {
    r = new System.Random();
    _difficulty = Difficulty.Easy;
    _partySize = (int)_difficulty + 1;
    _theme = GetRandomTheme();
    GenerateObjectiveObject();
  }

  public Quest(Difficulty difficulty)
  {
    r = new System.Random();
    _difficulty = difficulty;
    _partySize = (int)_difficulty + 1;
    _theme = GetRandomTheme();
    GenerateObjectiveObject();
  }

  public Quest(Difficulty difficulty, Theme theme)
  {
    r = new System.Random();
    _difficulty = difficulty;
    _partySize = (int)_difficulty + 1;
    _theme = theme;
    GenerateObjectiveObject();
  }

  public static Theme GetRandomTheme()
  {
    return (Theme)DiceRoller.Roll(0, Enum.GetValues(typeof(Theme)).Length);
  }

  public Location GetRandomLocation()
  {
    switch (_theme)
    {
      case Theme.Simple:
        return _locationsSimple[DiceRoller.GetRandomObject(_locationsSimple)];
      case Theme.Slay:
        return _locationsSlay[DiceRoller.GetRandomObject(_locationsSlay)];
      case Theme.Save:
        return _locationsSave[DiceRoller.GetRandomObject(_locationsSave)];
      case Theme.Steal:
        return _locationsSteal[DiceRoller.GetRandomObject(_locationsSteal)];
      default:
        return _locationsSimple[DiceRoller.GetRandomObject(_locationsSimple)];
    }
  }

  public void GenerateRewards()
  {
    _reward = new Reward(_difficulty, _theme);
  }

  public void GenerateObjectiveObject()
  {
    switch (_theme)
    {
      case Theme.Simple:
        _objectiveStringIndex = DiceRoller.GetRandomObject(_simpleObjects);
        _objectiveQuantity = DiceRoller.Roll(3, 6) * ((int)_difficulty + 1);
        break;
      case Theme.Slay:
        _objectiveStringIndex = DiceRoller.GetRandomObject(_slayObjects);
        _objectiveQuantity = DiceRoller.Roll(3, 6) * ((int)_difficulty + 1);
        break;
      case Theme.Save:
        _objectiveStringIndex = DiceRoller.GetRandomObject(_saveObjects);
        _objectiveQuantity = 1;
        break;
      case Theme.Steal:
        _objectiveStringIndex = DiceRoller.GetRandomObject(_stealObjects);
        _objectiveQuantity = 1;
        break;
      default:
        _objectiveStringIndex = DiceRoller.GetRandomObject(_simpleObjects);
        _objectiveQuantity = DiceRoller.Roll(3, 6) * ((int)_difficulty + 1);
        break;
    }
    _objectiveLocation = GetRandomLocation();
    GenerateRewards();
  }

  public string GetDifficultyName()
  {
    return Enum.GetName(typeof(Difficulty), _difficulty);
  }

  public string GetThemeName()
  {
    return Enum.GetName(typeof(Theme), _theme);
  }

  public Reward GetReward()
  {
    return _reward;
  }

  public int GetPartySize()
  {
    return _partySize;
  }

  public string GetObjectiveObjectName()
  {
    switch (_theme)
    {
      case Theme.Simple:
        return _simpleObjects[_objectiveStringIndex];
      case Theme.Slay:
        return _slayObjects[_objectiveStringIndex];
      case Theme.Save:
        return _saveObjects[_objectiveStringIndex];
      case Theme.Steal:
        return _stealObjects[_objectiveStringIndex];
      default:
        return _simpleObjects[_objectiveStringIndex];
    }
  }

  public string GetObjectiveLocationName()
  {
    return Enum.GetName(typeof(Location), _objectiveLocation);
  }

  public string GetQuestObjectiveText()
  {
    string theme = GetThemeName();
    string objective = GetObjectiveObjectName();
    string location = GetObjectiveLocationName();
    string plural = _objectiveQuantity > 1 ? "s" : "";

    if (_theme == Theme.Save)
    {
      return $"{theme} the {objective} in the {location}.";
    }
    if (_theme == Theme.Simple)
    {
      return $"Collect {_objectiveQuantity} {objective}{plural} in the {location}.";
    }
    return $"{theme} {_objectiveQuantity} {objective}{plural} in the {location}.";
  }
}
