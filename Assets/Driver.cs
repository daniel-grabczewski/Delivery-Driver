using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public bool isPickedUp = false;
    [SerializeField] float steerSpeed  = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
    }

  //   void OnTriggerEnter2D(Collider2D other) 
  //  {
  //   if (other.CompareTag("Package") && !isPickedUp)
  //   {
  //   }
  //   else if (other.CompareTag("PlayerCar") && isPickedUp) 
  //   {
  //   }
  // }

    void Update()
    { 
      float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
      float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
      transform.Rotate(0, 0, -steerAmount);
      transform.Translate(0, moveAmount, 0);

    }
}
