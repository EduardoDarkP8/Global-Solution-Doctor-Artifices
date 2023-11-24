using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWalkSound : MonoBehaviour
{
    public bool play;
    [SerializeField] AudioSource sound;
    void Start()
    {
        
    }

    void Update()
    {
		if (play) 
        {
            sound.Play();
            play = false;
        }
		
    }
}
