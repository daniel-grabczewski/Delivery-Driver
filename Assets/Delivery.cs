using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{ 
  [SerializeField] float delay;
  private bool isPickedUp = false;
  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Ouch!");
  }

   void OnTriggerEnter2D(Collider2D other) 
   {
    if (other.CompareTag("PlayerCar") && !isPickedUp)
    {
      PickUpPackage();
      Destroy(gameObject, delay);
    }
    else if (other.CompareTag("PlayerCar") && isPickedUp) 
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
