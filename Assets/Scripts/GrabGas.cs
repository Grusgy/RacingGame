using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GasUI>().gasAmount = 50;
        Destroy(gameObject);
    }
}
