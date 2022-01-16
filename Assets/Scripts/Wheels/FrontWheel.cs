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

    // Když se pneumatika dotkne zemì, nastaví bool frontWheelIsOnGroud na true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        car.frontWheelIsOnGround = true;
    }

    // Když se pneumatika odlepí ze zemì, nastaví bool frontWheelIsOnGroud na false
    private void OnTriggerExit2D(Collider2D collision)
    {
        car.frontWheelIsOnGround = false;
    }
}
