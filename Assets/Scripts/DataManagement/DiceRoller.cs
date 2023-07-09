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

  private static string[] maleNames = new string[] {
    "Jarlath",
    "Jareth",
    "Jaxon",
    "Jairus",
    "Javan",
    "Jethro",
    "Jaeger",
    "Jacen",
    "Jarek",
    "Jorian",
    "Jovian",
    "Jexen",
    "Jericho",
    "Jasper",
    "Jareth",
    "Janus",
    "Jaden",
    "Josiah",
    "Joachim",
    "Julian"
  };

  private static string[] femaleNames = new string[] {
    "Jocelyn",
    "Jessamine",
    "Jaelyn",
    "Juniper",
    "Juliette",
    "Jaina",
    "Jasmina",
    "Jessa",
    "Jaela",
    "Jovana",
    "Jayla",
    "Jemma",
    "Jacinda",
    "Jocasta",
    "Jovita",
    "Jadis",
    "Jazlyn",
    "Jacinta",
    "Jayne",
    "Jovita"
  };

  public static string GenerateName(bool isMale)
  {
    if (isMale)
    {
      return maleNames[r.Next(0, maleNames.Length)];
    }
    return femaleNames[r.Next(0, femaleNames.Length)];
  }
}
