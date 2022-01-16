using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Car : MonoBehaviour
{
    public bool isPressingGas;
    public bool isPressingBrake;
    public float xSpeed;
    public GameObject[] wheels;
    public bool frontWheelIsOnGround;
    public bool backWheelIsOnGround;
    public int distanceTraveled;
    public TMP_Text distanceTraveledText;

    private float gasPressValue;
    private float brakePressValue;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        //Když zmáèkne plyn, tak pøidá rychlost vpøed, pokud je auto aspoò na jednom z kol
        if(isPressingGas)
        {
            if (frontWheelIsOnGround || backWheelIsOnGround)
            {
                gasPressValue = 0.25f;
                gasPressValue += Time.deltaTime / 6;
                if (xSpeed < 6)
                {
                    xSpeed += Mathf.Pow(gasPressValue, 2);
                }
            }
        }
        else
        {
            gasPressValue = 0;
            if (xSpeed > 0)
            {
                xSpeed -= Time.deltaTime;
            }
        }
        //Když zmáèkne brzdu, tak pøidá rychlost dozadu, pokud je auto aspoò na jednom z kol
        if (isPressingBrake)
        {
            if (frontWheelIsOnGround || backWheelIsOnGround)
            {
                brakePressValue = 0.25f;
                brakePressValue += Time.deltaTime / 6;
                if (xSpeed > -6)
                {
                    xSpeed -= Mathf.Pow(brakePressValue, 2);
                }
            }
        }
        else
        {
            brakePressValue = 0;
            if (xSpeed > 0)
            {
                xSpeed += Time.deltaTime;
            }
        }


        // Nastaví rychlost auta
        rb.velocity = new Vector2(Mathf.Clamp(xSpeed,-4, 4), rb.velocity.y);

        // Roztoèí obì kola podle rychlosti
        foreach(GameObject wheel in wheels)
        {
            wheel.transform.Rotate(0, 0, -rb.velocity.x *50);
        }

        //Brání pøekroèení maximální rychlosti
        xSpeed = Mathf.Clamp(xSpeed, -6, 6);

        // Vypíše ujetou dálku do UI
        distanceTraveled = (int)transform.position.x;
        distanceTraveledText.text = distanceTraveled.ToString();
    }

    private void FixedUpdate()
    {
        // Rotace auta, pokud není ani jedním kolem na zemi
        if(!frontWheelIsOnGround && !backWheelIsOnGround)
        {
            if(isPressingGas)
            {
                rb.MoveRotation(rb.rotation - 100 * Time.fixedDeltaTime);
            }
            else if(isPressingBrake)
            {
                rb.MoveRotation(rb.rotation + 100 * Time.fixedDeltaTime);
            }
        }
    }
}
