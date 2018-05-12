using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour {


    public static PilotController p;
    public static float shipHealth = 10f;

    private static SoundManager soundManagerInstance = null;

    public Text humanAlienIndicator;
    public Text humanAlienIndicatorSubtext;

    public static float maxShipHealth = 10f;
    public static float travelTime = Config.travelTime;
    public static float currentTravelTime = 0f;
    public static SpriteRenderer cursor;
    public static GameLoop gl;
    public static float timeElapsed = 0f;
    public float tTime = 0f;
    public float maxTTime = 0f;
    public static float possesionMeter = 0f;
    public static float maxPossesion = 10f;
    public static float shipSpeed = 1f;
    public Bar healthBar;
    public Bar possesionBar;
    public Event currentEvent;
    public Event lastEvent = null;

    public static DamageOverlay dmgOverlay;
    public static List<Sprite> asteroidSprites;

    public static SoundManager getSoundManager()
    {
        if (soundManagerInstance == null)
            soundManagerInstance = FindObjectOfType<SoundManager>();
        return soundManagerInstance;
    }

    public static void wrongItemUsedOnStation()
    {
        //play sound
    }

    public static List<Sprite> mineSprites;
    public static List<Sprite> pirateShipSprites;

    public static void repairShip()
    {
        if (shipHealth < maxShipHealth)
            shipHealth += 0.05f;


    }

    public static void damageShipByArcWelder()
    {
        damageShip(0.05f);
        soundManagerInstance.PlaySingle(soundManagerInstance.Arc_Welder);
    }

    public static SpaceShip ship;
    public List<Event> events;
    public static Sprite defaultCursorSprite;

    public void switchControls()
    {



    }

    void Start()
    {
        soundManagerInstance = FindObjectOfType<SoundManager>();


    }

    public static void damageShipByASun()
    {
        if(!ship.shieldOvercharged)
        {
            damageShip(Config.sunDamage);
        }
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

        if(!ship.laserTurretFiring)
        {
            damageShip(Config.AsteroidDamage);
        }

    }

    public static void damageShip(float d)
    {

        shipHealth -= d;
        AudioClip[] explosions = new AudioClip[] {soundManagerInstance.explosion_1,soundManagerInstance.explosion_2,soundManagerInstance.explosion_3 };
        soundManagerInstance.PlayOneOf(explosions);
        playDamagedAnimation();

    }

    public static void playDamagedAnimation()
    {
        gl.fadeInRedOverlay();
    }


    public void fadeInRedOverlay()
    {

        dmgOverlay.engage = true;
        gl.StartCoroutine(shakeTheCamera());

    }

    public IEnumerator shakeTheCamera()
    {
        Camera.main.GetComponent<ShakeCameraOnDamage>().enabled = true;
        yield return new WaitForSeconds(Config.shakeCameraOnDamageTime);
        Camera.main.GetComponent<ShakeCameraOnDamage>().enabled = false;
    }

    void Awake ()
    {
        p = GameObject.Find("ThePilot").GetComponent<PilotController>();
        cursor = p.transform.Find("Cursor").GetComponent<SpriteRenderer>();
        defaultCursorSprite = cursor.sprite;

        Config.initControlScheme();
        gl = this;
        healthBar = GameObject.Find("ShipHealthBar").GetComponent<Bar>();
        ship = GameObject.Find("Spaceship").GetComponent<SpaceShip>();
        possesionBar = GameObject.Find("PossesionBar").GetComponent<Bar>();
        loadSprites();
        dmgOverlay = GameObject.Find("DamageOverlay").GetComponent<DamageOverlay>();
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
                    events.Add(new AsteroidEvent());
                    break;
                case 3:
                    events.Add(new MinesEvent());
                    break;


            }



        }


        float sTime = 5f;
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
        tTime = currentTravelTime;
        maxTTime = travelTime;
        if(possesionMeter > maxPossesion)
        {
            switchPossesion();


        }
        processEvents();

        currentTravelTime += Time.deltaTime * shipSpeed;
        timeElapsed += Time.deltaTime;

        

        if(shipHealth <= 0f)
            humanWins();
        else
        { 
            if (currentTravelTime >= travelTime)
                alienWins();
        }

    }

    public static void changeCursorToDefault()
    {
        cursor.sprite = defaultCursorSprite;
        cursor.transform.localScale = Vector3.one;
    }


    public static void changeCursorSpriteTo(Sprite s)
    {

        cursor.sprite = s;
        cursor.transform.localScale = Vector3.one * 2f;

    }

    public void alienWins()
    {
        Messages.showMessage("Alien Wins");

    }

    public void humanWins()
    {
        Messages.showMessage("Human Wins");
    }

    public void processEvents()
    {
        currentEvent = getCurrentEvent();
        if(currentEvent != lastEvent)
            {
            if (lastEvent != null)
                if(!lastEvent.ended)
                    lastEvent.onEndEvent();


            lastEvent = currentEvent;

        }
        if (currentEvent != null)
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
        possesionMeter = 0f;
        
        if (p.controlledByAlien)
        {
            p.a.SetBool("Possesed", false);
            p.tentacles.gameObject.SetActive(false);
            p.controlledByAlien = false;
            p.controlledByPilot = true;
            Config.switchControlScheme(Config.controlScheme, false);
            p.switchSpriteToHuman();
            soundManagerInstance.PlaySingle(soundManagerInstance.Human_control_back);

            humanAlienIndicator.text = "Pilot";
            humanAlienIndicatorSubtext.text = "Destroy the ship, end alien menace!";
        }
        else
        {
            p.a.SetBool("Possesed", true);
            p.controlledByAlien = true;
            p.tentacles.gameObject.SetActive(true);
            p.controlledByPilot = false;
            p.switchSpriteToAlien();
            Config.switchControlScheme(Config.controlScheme, true);
            soundManagerInstance.PlaySingle(soundManagerInstance.Alien_control);
            humanAlienIndicator.text = "Alien";
            humanAlienIndicatorSubtext.text = "Save the ship, visit Earth!";
        }

    }

    public static void changePossesionBar(float d)
    {
        possesionMeter += d * Config.movementPossesionChange;
        


    }
}
