using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
  public int CurrentDay { get; set; }
  public int MaxDay { get; private set; }

  // Start is called before the first frame update
  void Start()
  {
    CurrentDay = 1;
    MaxDay = 15;
  }

  // Update is called once per frame
  void Update()
  {

  }

}
