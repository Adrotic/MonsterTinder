using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone : MonoBehaviour
{
    public enum PhoneApp
    {
        love, text, location
    }
    public enum HoldState
    {
        up, down, movingUp, movingDown
    }

    public PhoneApp currentApp;
    public int service;
    public float holdSpeed;

    private Rect phoneRec;
    private Vector3 phonePos;

    public HoldState crHoldState;

    // Start is called before the first frame update
    void Start()
    {
        phonePos = GetComponent<Transform>().position;
        crHoldState = HoldState.up;
    }

    // Update is called once per frame
    void Update()
    {
        phonePos = GetComponent<Transform>().position;
        phoneRec = GetComponent<SpriteRenderer>().sprite.rect;
        Move();
    }
    void Move()
    {
        switch (crHoldState)
        {
            case HoldState.movingUp:
                if (phonePos.y + holdSpeed > 0) { SetPosition(0, 0); }
                else { ShiftPosition(0, holdSpeed); }
                if (phonePos.y >= 0) 
                {
                    crHoldState = HoldState.up;
                }
                break;
            case HoldState.movingDown:
                if (phonePos.y - holdSpeed > 0) { SetPosition(0,0 - phoneRec.height / 100); }
                else { ShiftPosition(0, -holdSpeed); }
                if (phonePos.y <= 0 - phoneRec.height / 100)
                {
                    crHoldState = HoldState.down;
                }
                break;
            case HoldState.down:
                SetPosition(0, 0 - phoneRec.height / 100);
                break;
            case HoldState.up:
                SetPosition(0, 0);
                break;
        }
    }

    private void ShiftPosition(float x, float y)
    {
        Vector3 phonePos = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(phonePos.x + x, phonePos.y + y, phonePos.z);
    }
    private void SetPosition(float x, float y)
    {
        GetComponent<Transform>().position = new Vector3(x,y, phonePos.z);
    }
    public void ToggleHeldPhonePosition(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switch (crHoldState)
            {
                case HoldState.up:
                case HoldState.movingUp:
                    crHoldState = HoldState.movingDown;
                    break;
                case HoldState.down:
                case HoldState.movingDown:
                    crHoldState = HoldState.movingUp;
                    break;
            }
        }
    }
}
