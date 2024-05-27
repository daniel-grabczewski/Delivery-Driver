using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public bool isPickedUp = false;
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(0, 255, 0, 255);

    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float slowDuration = 2f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float boostDuration = 2f;

    SpriteRenderer spriteRenderer;
    private float originalSpeed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
        originalSpeed = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
          Delivery delivery = other.GetComponent<Delivery>();

        if (other.CompareTag("Package") && !isPickedUp)
        {
            spriteRenderer.color = hasPackageColor;
            isPickedUp = true;
            Destroy(other.gameObject, delivery.delay);
        }
        else if (other.CompareTag("Customer") && isPickedUp)
        {
            spriteRenderer.color = noPackageColor;
            isPickedUp = false;
            Destroy(other.gameObject, delivery.delay);
        }
        else if (other.CompareTag("SpeedUp")) {
          moveSpeed = boostSpeed;
          Invoke(nameof(ResetSpeed), boostDuration);
          Debug.Log("Speedup for " + boostDuration + " seconds!");
        }
    }


    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Obstacle")) {
          moveSpeed = slowSpeed;
          Invoke(nameof(ResetSpeed), slowDuration);
          Debug.Log("Slowed for " + slowDuration + " seconds!");
        }
    }

    void ResetSpeed() 
    {
      moveSpeed = originalSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
