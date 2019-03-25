﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    
    public AudioSource source;
    public AudioClip walkingSound;

    private bool isSoundPlaying = false;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoUp");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoDown");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoRight");
        }

        if (!Input.anyKey)
        {
            anim.Play("CatIdle2");
            source.Stop();
            isSoundPlaying = false;
        }

    }

    void PlaySound(AudioClip clip)
    {
        if(!isSoundPlaying)
        {
            source.loop = true;
            source.clip = clip;
            source.Play();
            isSoundPlaying = true;
        }
    }
}
