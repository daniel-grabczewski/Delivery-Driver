using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Driver : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
      transform.Rotate(0, 0, 0.1f);
      transform.Translate(1, 0.01f, 0);
    }
}
