using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionManager : MonoBehaviour
{
  public int CurrentCorruption { get; set; }
  public int MaxCorruption { get; private set; }

  // Start is called before the first frame update
  void Start()
  {
    CurrentCorruption = 5;
    MaxCorruption = 50;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
