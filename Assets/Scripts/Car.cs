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
        //Kdy� zm��kne plyn, tak p�id� rychlost vp�ed, pokud je auto aspo� na jednom z kol
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
        //Kdy� zm��kne brzdu, tak p�id� rychlost dozadu, pokud je auto aspo� na jednom z kol
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


        // Nastav� rychlost auta
        rb.velocity = new Vector2(Mathf.Clamp(xSpeed,-4, 4), rb.velocity.y);

        // Rozto�� ob� kola podle rychlosti
        foreach(GameObject wheel in wheels)
        {
            wheel.transform.Rotate(0, 0, -rb.velocity.x *50);
        }

        //Br�n� p�ekro�en� maxim�ln� rychlosti
        xSpeed = Mathf.Clamp(xSpeed, -6, 6);

        // Vyp�e ujetou d�lku do UI
        distanceTraveled = (int)transform.position.x;
        distanceTraveledText.text = distanceTraveled.ToString();
    }

    private void FixedUpdate()
    {
        // Rotace auta, pokud nen� ani jedn�m kolem na zemi
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
