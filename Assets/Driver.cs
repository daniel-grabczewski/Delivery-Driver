using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public bool isPickedUp = false;
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(0, 255, 0, 255);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && isPickedUp)
        {
            spriteRenderer.color = hasPackageColor;
            isPickedUp = true;
        }
        else if (other.CompareTag("Customer") && !isPickedUp)
        {
            spriteRenderer.color = noPackageColor;
            isPickedUp = false;
        }
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
