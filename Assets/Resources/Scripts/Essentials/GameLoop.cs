using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {


    public static PilotController p;
    public static float shipHealth = 10f;
    public static float maxShipHealth = 10f;
    public static float travelTime = Config.travelTime;
    public static float currentTravelTime = 0f;

   
    public static float timeElapsed = 0f;
    public static float possesionMeter = 0f;
    public static float maxPossesion = 10f;
    public static float shipSpeed = 1f;
    public Bar healthBar;
    public Bar possesionBar;
    public Event currentEvent;


    public static List<Sprite> asteroidSprites;
    public static List<Sprite> mineSprites;
    public static List<Sprite> pirateShipSprites;



    public static SpaceShip ship;
    public List<Event> events;

    public void switchControls()
    {



    }

    void Start()
    {



    }


    public static void damageShipByAMine()
    {
        if (!ship.helmEngaged)
        {
            damageShip(Config.AsteroidDamage);
        }
    }

    public static void damageShipByAsteroid()
    {

        if(!ship.shieldOvercharged)
        {
            damageShip(Config.AsteroidDamage);
        }

    }

    public static void damageShip(float d)
    {

        shipHealth -= d;
        playDamagedAnimation();

    }

    public static void playDamagedAnimation()
    {
        
    }

    void Awake ()
    {
        Config.initControlScheme();

        p = GameObject.Find("ThePilot").GetComponent<PilotController>();
        healthBar = GameObject.Find("ShipHealthBar").GetComponent<Bar>();
        ship = GameObject.Find("Spaceship").GetComponent<SpaceShip>();
        possesionBar = GameObject.Find("PossesionBar").GetComponent<Bar>();
        loadSprites();

        placeItemsRandomly();
        generateEventList();
    }

    public void loadSprites()
    {

        asteroidSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Resources/Sprites/Events/Asteroids"));
        mineSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Resources/Sprites/Events/Mines"));
        pirateShipSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Resources/Sprites/Events/PirateShips"));

    }

    public void generateEventList()
    {
        events = new List<Event>();

        
        int numOfEvents = UnityEngine.Random.Range(Config.minEvents, Config.maxEvents);

        int lastEvent = -1;
        
        
        for(int i = 0;i<=numOfEvents;i++)
        {
            int r = UnityEngine.Random.Range(0, 4);
            while (r == lastEvent)
                r = UnityEngine.Random.Range(0, 4);

            lastEvent = r;

            switch(r)
            {
                case 0:
                    events.Add(new AsteroidEvent());
                    break;
                case 1:
                    events.Add(new SunEvent());
                    break;
                case 2:
                    events.Add(new PirateEvent());
                    break;
                case 3:
                    events.Add(new MinesEvent());
                    break;


            }



        }


        float sTime = 30f;
        foreach(Event e in events)
        {
            e.initEvent(sTime);
            sTime = e.endTime + UnityEngine.Random.Range(Config.minNoEventsTime, Config.maxNoEventsTime);
        }







    }

    public void placeItemsRandomly()
    {
        
    }

    void Update ()
    {
        healthBar.percentFilled = shipHealth / maxShipHealth;
        possesionBar.percentFilled = possesionMeter / maxPossesion;
        possesionMeter += Config.constantPossesionChange;

        if(possesionMeter > maxPossesion)
        {
            switchPossesion();


        }
        processEvents();

        currentTravelTime += Time.deltaTime * shipSpeed;
        timeElapsed += Time.deltaTime;



        if(shipHealth <= 0f)
            humanWins();

        if (currentTravelTime >= travelTime)
            alienWins();
        
	}

    public void alienWins()
    {
        
    }

    public void humanWins()
    {

    }

    public void processEvents()
    {
        currentEvent = getCurrentEvent();
        if(currentEvent != null)
        {
            currentEvent.processEvent();
        }

    }

    public Event getCurrentEvent()
    {
        Event retEvent = null;
        foreach(Event e in events)
        {
            if(timeElapsed > e.startTime && timeElapsed < e.endTime)
            {
                retEvent = e;
                break;
            }
        }

        return retEvent;
    }

    public void switchPossesion()
    {
        
    }

    public static void changePossesionBar(float d)
    {
        possesionMeter += d * Config.movementPossesionChange;
        


    }
}
