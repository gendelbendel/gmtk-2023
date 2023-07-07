using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiver : MonoBehaviour
{

  private Vector2 movementInput;

  [SerializeField]
  private InputActionReference movement;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      movementInput = movement.action.ReadValue<Vector2>();
      
  }
}
