using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    [SerializeField] private GameObject BrakeUI;

    private Car car;

    private void Start()
    {
        car = FindObjectOfType<Car>();
    }
    private void OnMouseDown()
    {
        car.isPressingBrake = true;
        BrakeUI.GetComponent<Animator>().SetBool("isPressed", true);
    }

    private void OnMouseUp()
    {
        car.isPressingBrake = false;
        BrakeUI.GetComponent<Animator>().SetBool("isPressed", false);
    }
}
