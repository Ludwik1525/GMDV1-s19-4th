using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    
    private AudioSource source;

    private AudioClip walkingSound;

    private GameManager manager;

    private bool isSoundPlaying = false;

    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        anim = GetComponent<Animator>();

        source = manager.gameSoundsSource;

        walkingSound = manager.playerWalkingSound;
    }
	
	void Update () {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoUp");
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoDown");
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            PlaySound(walkingSound);
            anim.Play("CatGoLeft");
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
