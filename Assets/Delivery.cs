using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{ 
  [SerializeField] float delay;
  
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
        Destroy(gameObject, delay);
      }
      else if (CompareTag("Customer") && driver.isPickedUp)
      {
        Destroy(gameObject, delay);
      }
    }
  }


}
