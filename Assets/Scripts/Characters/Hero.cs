using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Characters
{
  public class Hero : MonoBehaviour
  {
    //(Name, Level, XP, GoldInventory, Class, Cost, Status)
    [SerializeField]

    public string Name { get; set; }
    public int Level { get; set; }
    public int XP { get; set; }
    public int GoldInventory { get; set; }
    public string Class { get; set; }
    public int Cost { get; set; }
    public int Status { get; set; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}