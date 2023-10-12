using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicControll : MonoBehaviour
{
    [SerializeField] private AudioSource[] audios;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
       // audio[0].Play();
    }
    public void runningSound(bool isPlay)
    {
        if (isPlay==true )
        {
            if (audios[1].isPlaying == false)
            {
                audios[1].Play();
            }
        }
        else
        {
            audios[1].Stop();
        }

    }
    public void switchSound(bool isPlay)
    {
        if (isPlay == true)
        {
            if (audios[2].isPlaying == false)
            {
                audios[2].Play();
            }
        }
        else
        {
            audios[2].Stop();
        }

    }

}
