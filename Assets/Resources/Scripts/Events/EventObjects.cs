using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObjects : MonoBehaviour {

    public static ParticleSystem asteroids;
    public static ParticleSystem mines;
    public static ParticleSystem pirates;


    public void Awake()
    {
        asteroids = transform.Find("AsteroidField").GetComponent<ParticleSystem>();
        mines = transform.Find("MineField").GetComponent<ParticleSystem>();
        pirates = transform.Find("PirateShipFleet").GetComponent<ParticleSystem>();


    }

    public static void stopAllParticleSystems()
    {

        asteroids.Stop();
        mines.Stop();
        pirates.Stop();

    }
    


}
