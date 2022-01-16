using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasUI : MonoBehaviour
{
    public float gasAmount;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        gasAmount = 50;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        gasAmount -= Time.deltaTime * 3;
        slider.value = gasAmount;
        if(gasAmount <= 0)
        {
            FindObjectOfType<Death>().OnDeath();
        }
    }
}
