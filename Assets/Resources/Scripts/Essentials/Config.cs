using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    public static float CursorSpeed = 0.1f;
    public static float travelTime = 10;

    public enum ControlScheme
    {
        XboxController = 0,
        KeybordAndMouse = 1,
        PlayStationController = 2
    }

    public static ControlScheme controlScheme = 0;
    public static List<KeyCode> buttons;
    public static List<KeyCode> player1useOrPickupKeys;
    public static List<KeyCode> player1dropKeys;
    public static List<KeyCode> player2useOrPickupKeys;
    public static List<KeyCode> player2dropKeys;
    public static float keyRemovalTime = 0.2f;
    public static float constantPossesionChange = 0.0005f;
    public static float movementPossesionChange = 0.01f;
    public static int minEvents = 4;
    public static int maxEvents = 7;
    public static float minNoEventsTime = 10f;
    public static float maxNoEventsTime = 25f;

    public static void switchControlScheme(ControlScheme newScheme)
    public static float AsteroidDamageTime = 3f;
    public static float AsteroidDamage = 0.2f;
    public static float MinesDamageTime = 3f;
    public static float MinesDamage = 3f;

    public static float PirateDamageTime = 3f;
    public static float PirateDamage = 3f;



    public static void switchControlScheme(int scheme)
    {
        List<KeyCode> currentControls = new List<KeyCode>();
        controlScheme = newScheme;
        switch(newScheme)
        {
            case ControlScheme.XboxController:
                currentControls.Add(KeyCode.Joystick1Button0); // A button
                currentControls.Add(KeyCode.Joystick1Button1); // B button
                currentControls.Add(KeyCode.Joystick2Button0);
                currentControls.Add(KeyCode.Joystick2Button1);
                break;
            case ControlScheme.KeybordAndMouse:
                currentControls.Add(KeyCode.Mouse0);
                currentControls.Add(KeyCode.Mouse1);
                currentControls.Add(KeyCode.Mouse0);
                currentControls.Add(KeyCode.Mouse1);
                break;
            case ControlScheme.PlayStationController:
                currentControls.Add(KeyCode.Joystick1Button1); // X button on PS4 controller
                currentControls.Add(KeyCode.Joystick1Button2); // O button on PS4 controller
                currentControls.Add(KeyCode.Joystick2Button1);
                currentControls.Add(KeyCode.Joystick2Button2);
                break;
        }
        buttons = currentControls;
    }

    public static void initControlScheme()
    {
        buttons = new List<KeyCode>();
        player1useOrPickupKeys = new List<KeyCode>();
        player1dropKeys = new List<KeyCode>();
        player2useOrPickupKeys = new List<KeyCode>();
        player2dropKeys = new List<KeyCode>();

        player1useOrPickupKeys.Add(KeyCode.Joystick1Button0);
        player1useOrPickupKeys.Add(KeyCode.Mouse0);
        player1useOrPickupKeys.Add(KeyCode.Joystick1Button1);

        player1dropKeys.Add(KeyCode.Joystick1Button1);
        player1dropKeys.Add(KeyCode.Mouse1);
        player1dropKeys.Add(KeyCode.Joystick1Button2);

        player2useOrPickupKeys.Add(KeyCode.Joystick2Button0);
        player2useOrPickupKeys.Add(KeyCode.Mouse0);
        player2useOrPickupKeys.Add(KeyCode.Joystick2Button1);

        player2dropKeys.Add(KeyCode.Joystick2Button1);
        player2dropKeys.Add(KeyCode.Mouse1);
        player2dropKeys.Add(KeyCode.Joystick2Button2);

        switchControlScheme(controlScheme);
    }
}
