using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicControll : MonoBehaviour
{
    [SerializeField] private AudioSource[] audio;
    public float delayBetweenLoops;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponents<AudioSource>();
       // audio[0].Play();
    }
    public void runningSound(bool isPlay)
    {
        if (isPlay==true )
        {
            if (audio[1].isPlaying == false)
            {
                audio[1].Play();
            }
        }
        else
        {
            audio[1].Stop();
        }

    }
    public void switchSound(bool isPlay)
    {
        if (isPlay == true)
        {
            if (audio[2].isPlaying == false)
            {
                audio[2].Play();
            }
        }
        else
        {
            audio[2].Stop();
        }

    }

}
