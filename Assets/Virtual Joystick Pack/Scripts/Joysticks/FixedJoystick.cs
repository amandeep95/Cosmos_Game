﻿using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    Vector2 joystickPosition = Vector2.zero;
    public Vector2 startpos;
    private Camera cam = new Camera();

    //adding boolean to check if the joystick should stay in its place
    public bool FreezeJoystickPos, choosePosition;

    void Start()
    {
        if (choosePosition)
        {
            //joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, startpos);
        }
        else
        {
            //joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (!FreezeJoystickPos)
        {
            inputVector = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }
    }
}