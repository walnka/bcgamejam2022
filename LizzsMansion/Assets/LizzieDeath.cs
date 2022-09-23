using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizzieDeath : MonoBehaviour
{
    public AudioSource musicHandler;
    AudioSource playMusic;
    bool didAlready;
    // Start is called before the first frame update
    void Start()
    {
        playMusic = GetComponent<AudioSource>();
        didAlready = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuckinghamPalace()
    {
        if (!didAlready)
        {
            musicHandler.Stop();
            playMusic.Play();
            didAlready = true;
        }
        
    }
}
