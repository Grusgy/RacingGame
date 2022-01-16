using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    [SerializeField] private GameObject GasUI;

    private Car car;

    private void Start()
    {
        car = FindObjectOfType<Car>();
    }

    private void OnMouseDown()
    {
        car.isPressingGas = true;
        GasUI.GetComponent<Animator>().SetBool("isPressed", true);
    }

    private void OnMouseUp()
    {
        car.isPressingGas = false;
        GasUI.GetComponent<Animator>().SetBool("isPressed", false);
    }
}
