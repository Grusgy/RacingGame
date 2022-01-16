using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWheel : MonoBehaviour
{
    private Car car;

    private void Start()
    {
        car = FindObjectOfType<Car>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        car.backWheelIsOnGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        car.backWheelIsOnGround = false;
    }
}
