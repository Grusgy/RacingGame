using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheel : MonoBehaviour
{
    private Car car;

    private void Start()
    {
        car = FindObjectOfType<Car>();
    }

    // Kdy� se pneumatika dotkne zem�, nastav� bool frontWheelIsOnGroud na true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        car.frontWheelIsOnGround = true;
    }

    // Kdy� se pneumatika odlep� ze zem�, nastav� bool frontWheelIsOnGroud na false
    private void OnTriggerExit2D(Collider2D collision)
    {
        car.frontWheelIsOnGround = false;
    }
}
