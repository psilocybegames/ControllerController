using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObjects : MonoBehaviour {

    public static ParticleSystem asteroids;
    public static ParticleSystem smallasteroids;
    public static ParticleSystem mines;
    public static ParticleSystem pirates;
    public static ParticleSystem sun;

    
    public void Awake()
    {
        asteroids = transform.Find("AsteroidField").GetComponent<ParticleSystem>();
        smallasteroids = transform.Find("AsteroidField").Find("SmallAsteroids").GetComponent<ParticleSystem>();
        sun = transform.Find("TheSun").GetComponent<ParticleSystem>();

        mines = transform.Find("MineField").GetComponent<ParticleSystem>();
        pirates = transform.Find("PirateShipFleet").GetComponent<ParticleSystem>();
        stopAllParticleSystems();

    }


    public static void startSwayingVertically()
    {
        ParticleSystem.MinMaxCurve m = new ParticleSystem.MinMaxCurve(10f,AnimationCurve.EaseInOut(0f, -10f, 0.1f, 10f));
        var v = asteroids.velocityOverLifetime;
        v.y = m;
        var vsmallasteroids = smallasteroids.velocityOverLifetime;
        vsmallasteroids.y = m;
        var vmines = mines.velocityOverLifetime;
        vmines.y = m;
        var vpirates = pirates.velocityOverLifetime;
        vpirates.y = m;

    }

    public static void stopSwayingVertically()
    {
        ParticleSystem.MinMaxCurve m = new ParticleSystem.MinMaxCurve(0f);
        var v = asteroids.velocityOverLifetime;
        v.y = m;
        var vsmallasteroids = smallasteroids.velocityOverLifetime;
        vsmallasteroids.y = m;
        var vmines = mines.velocityOverLifetime;
        vmines.y = m;
        var vpirates = pirates.velocityOverLifetime;
        vpirates.y = m;

    }

    public static void setAllParticleSystemSpeed()
    {


        ParticleSystem.MinMaxCurve m = new ParticleSystem.MinMaxCurve(-GameLoop.ship.shipSpeed, -GameLoop.ship.shipSpeed / 2f);
        var v = asteroids.velocityOverLifetime;
        v.x = m;
        var vsmallasteroids = smallasteroids.velocityOverLifetime;
        vsmallasteroids.x = m;
        var vmines = mines.velocityOverLifetime;
        vmines.x = m;
        var vpirates = pirates.velocityOverLifetime;
        vpirates.x = m;
        


    }

    public static void stopAllParticleSystems()
    {

        asteroids.Stop();
        mines.Stop();
        pirates.Stop();
        sun.Stop();
        smallasteroids.Stop();

    }



}
