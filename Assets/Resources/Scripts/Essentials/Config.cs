﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    public static float CursorSpeed = 0.1f;
    public static float travelTime = 400;



    public static int controlScheme = 0;


    public static int xboxControlScheme = 0;
    public static int keyboardControlScheme = 1;
    public static int psControlScheme = 2;
    public static List<KeyCode> buttons;
    public static float keyRemovalTime = 0.2f;
    public static float constantPossesionChange = 0.0005f;
    public static float movementPossesionChange = 0.01f;

    public static void switchControlScheme(int scheme)
    {



    }

    public static void initControlScheme()
    {
        buttons = new List<KeyCode>();

    }
}
