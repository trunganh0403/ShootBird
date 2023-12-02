using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public static Audios Instance;
    AudioSource audioS;
    public AudioClip shoot;
    public AudioClip win;
    public AudioClip loss;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
      
            
       
    }
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        if(win != null)
        {
            audioS.clip = win;
            audioS.Play();
        }
       
    }
    public void PlayShoot()
    {
        if (shoot != null)
        {
            audioS.clip = shoot;
            audioS.Play();
        }

    }
    public void PlayLoss()
    {
        if (loss != null)
        {
            audioS.clip = loss;
            audioS.Play();
        }

    }
}
