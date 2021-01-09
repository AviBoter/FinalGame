
using UnityEngine.Audio;
using UnityEngine;

[ System.SerializableAttribute]
public class Sound
{
    public string SoundName;
    public AudioClip audio;

    [Range(0f,1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource sorce;

}

    