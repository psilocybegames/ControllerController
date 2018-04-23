using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    public static float CursorSpeed = 3f;
    public static float travelTime = 200;

    public enum ControlScheme
    {
        XboxController = 0,
        KeybordAndMouse = 1,
        PlayStationController = 2
    }

    public static ControlScheme controlScheme = 0;

    public static KeyCode player1UpKey = KeyCode.W;
    public static KeyCode player1DownKey = KeyCode.S;
    public static KeyCode player1LeftKey = KeyCode.A;
    public static KeyCode player1RightKey = KeyCode.D;

    public static KeyCode player2UpKey = KeyCode.UpArrow;
    public static KeyCode player2DownKey = KeyCode.DownArrow;
    public static KeyCode player2LeftKey = KeyCode.LeftArrow;
    public static KeyCode player2RightKey = KeyCode.RightArrow;

    public static KeyCode dropItemKey;
    public static KeyCode pickUpUseItemKey;

    public static KeyCode buttonA;
    public static KeyCode buttonB;
    public static KeyCode buttonX;
    public static KeyCode buttonY;




    public static float keyRemovalTime = 0.2f;
    public static float constantPossesionChange = 0.01000f;
    public static float movementPossesionChange = 0.01f;
    public static int minEvents = 4;
    public static int maxEvents = 7;
    public static float minNoEventsTime = 5f;
    public static float maxNoEventsTime = 10f;

    public static float AsteroidDamageTime = 5f;
    public static float AsteroidDamage = 0.5f;
    public static float MinesDamageTime = 3f;
    public static float MinesDamage = 0.5f;

    public static float PirateDamageTime = 3f;
    public static float PirateDamage = 3f;
    public static float shakeCameraOnDamageTime = 0.3f;
    public static float cameraShakeFactor = 0.01f;
    public static float DamageFlashTime = 0.1f;
    public static float sunDamage = 0.1f;
    public static float sunDamageTime = 1f;
    public static List<KeyCode> buttons;
    public static float shipSpeedNormal = 2f;
    public static float shipSpeedFast = 6f;
    public static KeyCode pickUpUseItemKeyboadKey;
    public static KeyCode dropItemKeyboardKey;
    public static float disappearMessageTime = 5f;

    public static void switchControlScheme(ControlScheme newScheme, bool alienInControl)
    {
        buttons = new List<KeyCode>();
        List<KeyCode> currentControls = new List<KeyCode>();
        controlScheme = newScheme;
        if(alienInControl)
        {

            pickUpUseItemKeyboadKey = KeyCode.Return;
            dropItemKeyboardKey = KeyCode.Keypad0;

            switch (newScheme)
        {
            case ControlScheme.XboxController:

                dropItemKey = KeyCode.Joystick2Button1;
                pickUpUseItemKey = KeyCode.Joystick2Button0;
                buttonA = KeyCode.Joystick2Button0;
                buttonB = KeyCode.Joystick2Button1;
                buttonX = KeyCode.Joystick2Button2;
                buttonY = KeyCode.Joystick2Button3;
                break;
            case ControlScheme.KeybordAndMouse:
                dropItemKey = KeyCode.Mouse1;
                pickUpUseItemKey = KeyCode.Mouse0;
                buttonA = KeyCode.Mouse0;
                buttonB = KeyCode.Mouse1;
                buttonX = 0;
                buttonY = 0;
                break;
            case ControlScheme.PlayStationController:
                dropItemKey = KeyCode.Joystick2Button2;
                pickUpUseItemKey = KeyCode.Joystick2Button0;
                buttonA = KeyCode.Joystick2Button0;
                buttonB = KeyCode.Joystick2Button1;
                buttonX = KeyCode.Joystick2Button2;
                buttonY = KeyCode.Joystick2Button3;
                break;
        }

        }
        else
        {

            pickUpUseItemKeyboadKey = KeyCode.Space;
            dropItemKeyboardKey = KeyCode.Tab;
            switch (newScheme)
            {
                case ControlScheme.XboxController:

                    dropItemKey = KeyCode.Joystick1Button1;
                    pickUpUseItemKey = KeyCode.Joystick1Button0;
                    buttonA = KeyCode.Joystick1Button0;
                    buttonB = KeyCode.Joystick1Button1;
                    buttonX = KeyCode.Joystick1Button2;
                    buttonY = KeyCode.Joystick1Button3;
                    break;
                case ControlScheme.KeybordAndMouse:
                    dropItemKey = KeyCode.Mouse1;
                    pickUpUseItemKey = KeyCode.Mouse0;
                    buttonA = KeyCode.Mouse0;
                    buttonB = KeyCode.Mouse1;
                    buttonX = 0;
                    buttonY = 0;
                    break;
                case ControlScheme.PlayStationController:
                    dropItemKey = KeyCode.Joystick2Button2;
                    pickUpUseItemKey = KeyCode.Joystick2Button0;
                    buttonA = KeyCode.Joystick1Button0;
                    buttonB = KeyCode.Joystick1Button1;
                    buttonX = KeyCode.Joystick1Button2;
                    buttonY = KeyCode.Joystick1Button3;
                    break;
            }


        }


        buttons.Add(buttonA);
        buttons.Add(buttonB);
        buttons.Add(buttonX);
        buttons.Add(buttonY);
    }

    public static void initControlScheme()
    {
        switchControlScheme(controlScheme,GameLoop.p.controlledByAlien);
    }
}
