using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{ 
  [SerializeField] public float delay;
  
  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Ouch!");
  }
}
