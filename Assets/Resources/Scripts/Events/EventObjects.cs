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

    public static void stopAllParticleSystems()
    {

        asteroids.Stop();
        mines.Stop();
        pirates.Stop();
        sun.Stop();
        smallasteroids.Stop();

    }



}
