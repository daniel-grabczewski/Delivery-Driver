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
    if (other.CompareTag("PlayerCar"))
    {
      Driver driver = other.GetComponent<Driver>();

      if (CompareTag("Package") && !driver.isPickedUp)
      {
        PickUpPackage(driver);
        Destroy(gameObject, delay);
      }
      else if (CompareTag("Customer") && driver.isPickedUp)
      {
        DeliverPackage(driver);
        Destroy(gameObject, delay);
      }
    }
  }

  private void PickUpPackage(Driver driver)
  {
    Debug.Log("Package picked up");
    driver.isPickedUp = true;
  }

  private void DeliverPackage(Driver driver) {
      Debug.Log("Package delivered!");
      driver.isPickedUp = false;
  }

}
