using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Play(string play)
    {
        Sound cur = Array.Find(sounds, sound => sound.SoundName.Equals(play));
        cur.sorce.Play();
    }
}
