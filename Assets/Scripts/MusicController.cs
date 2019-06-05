using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject DontDestroy;
    public AudioSource Music0;
    public AudioSource Music1;
    public AudioSource Music2;
    public AudioSource Music3;

    private void Awake()
    {
        if(Globals.MusicCreated)
        {
            Destroy(DontDestroy);
        }
        Globals.MusicCreated = true;
        DontDestroyOnLoad(DontDestroy);
        if (Globals.MusicType == 0)
        {
            Music1.Stop();
            Music2.Stop();
            Music3.Stop();
            Music1.mute = true;
            Music2.mute = true;
            Music3.mute = true;
        }
        else if (Globals.MusicType == 1)
        {
            Music0.Stop();
            Music2.Stop();
            Music3.Stop();
            Music0.mute = true;
            Music2.mute = true;
            Music3.mute = true;
        }
        else if (Globals.MusicType == 2)
        {
            Music0.Stop();
            Music1.Stop();
            Music3.Stop();
            Music0.mute = true;
            Music1.mute = true;
            Music3.mute = true;
        }
        else if (Globals.MusicType == 3)
        {
            Music0.Stop();
            Music1.Stop();
            Music2.Stop();
            Music0.mute = true;
            Music1.mute = true;
            Music2.mute = true;
        }
    }
    void Update()
    {
        if (Globals.ChangeMusic)
        {
            Debug.Log("Changing music");
            Music0.Stop();
            Music1.Stop();
            Music2.Stop();
            Music3.Stop();

            Music0.mute = true;
            Music1.mute = true;
            Music2.mute = true;
            Music3.mute = true;
            if (Globals.MusicType == 0)
            {
                Debug.Log("Playing music 0");
                Music0.Play(0);
                Music0.mute = false;
            }
            else if (Globals.MusicType == 1)
            {
                Debug.Log("Playing music 1");
                Music1.Play(1);
                Music1.mute = false;
            }
            else if (Globals.MusicType == 2)
            {
                Debug.Log("Playing music 2");
                Music2.Play(2);
                Music2.mute = false;
            }
            else if (Globals.MusicType == 3)
            {
                Debug.Log("Playing music 3");
                Music3.Play(3);
                Music3.mute = false;
            }
            Globals.ChangeMusic = false;
        }
    }
}
