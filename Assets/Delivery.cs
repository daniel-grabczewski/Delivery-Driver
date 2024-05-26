using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{ 

  bool isPickedUp = false;
  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Ouch!");
  }

   void OnTriggerEnter2D(Collider2D other) 
   {
    if (other.CompareTag("Package") && isPickedUp == false)
    {
      Debug.Log("Package picked up");
      isPickedUp = true;
    }
    else if (other.CompareTag("Customer") && isPickedUp == true ) 
    {
      Debug.Log("Package delivered!");
      isPickedUp = false;
    }
  }
}
