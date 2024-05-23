using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ 
  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Ouch!");
  }

  
}
