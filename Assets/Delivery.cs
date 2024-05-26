using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{ 

  private bool isPickedUp = false;
  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Ouch!");
  }

   void OnTriggerEnter2D(Collider2D other) 
   {
    if (other.CompareTag("Package") && !isPickedUp)
    {
      PickUpPackage();
    }
    else if (other.CompareTag("Customer") && isPickedUp) 
    {
      DeliverPackage();
    }
  }

  private void PickUpPackage()
  {
    Debug.Log("Package picked up");
    isPickedUp = true;
  }

  private void DeliverPackage() {
      Debug.Log("Package delivered!");
      isPickedUp = false;
  }

}
