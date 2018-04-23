using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;                   //Drag a reference to the audio source which will play the sound effects.
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    public AudioClip Zoink_sound;
    public AudioClip Sun_frying;
    public AudioClip Shields_shimmering_2;
    public AudioClip Shield_collision_laser;
    public AudioClip Shield_colission_mine;
    public AudioClip Shield_colission_asteroid;
    public AudioClip shield_overcharge_full;
    public AudioClip Human_control_back;
    public AudioClip heavy_cannon;
    public AudioClip explosion_2;
    public AudioClip explosion_1;
    public AudioClip Engine_humm;
    public AudioClip Engine_Overcharge_Redux;
    public AudioClip disengage_autopilot;
    public AudioClip Arc_Welder;
    public AudioClip Alien_control;
    public AudioClip alien_possession;
    public AudioClip tentacle;
    public AudioClip laser_zap;
    public AudioClip footstep_metal;
    public AudioClip explosion_3;

    public void PlaySingle(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}