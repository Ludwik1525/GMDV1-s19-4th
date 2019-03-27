using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsManager : MonoBehaviour
{
    private Vector2 startPosition;
    private TimeCounter counter;

    private GameManager manager;

    private AudioSource source;

    private AudioClip receiveDMGSound;
    private AudioClip deathSound;
    private AudioClip winSound;

    private GameplayEventsManager eventsManager;

    void Start ()
    {
        Time.timeScale = 1.0f;

        counter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TimeCounter>();
        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        eventsManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameplayEventsManager>();

        startPosition = transform.position;

        source = manager.gameSoundsSource1;

        receiveDMGSound = manager.playerReceiveDMGSound;
        deathSound = manager.playerDeathSound;
        winSound = manager.levelCompletedSound;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Worm")|| other.gameObject.CompareTag("Golem")|| other.gameObject.CompareTag("Blackman")|| other.gameObject.CompareTag("Flame")|| other.gameObject.CompareTag("Spider")|| other.gameObject.CompareTag("Skeleton"))
        {
            if(eventsManager.lives>1)
            {
                source.PlayOneShot(receiveDMGSound);
            }
            else
            {
                source.PlayOneShot(deathSound);
            }

            //teleport to some position after touching the enemy
            transform.position = transform.position + new Vector3(startPosition.x - transform.position.x, startPosition.y - transform.position.y, 0);
            
            //deal dmg after touching the enemy
            eventsManager.DealDMG();
        }

        //display win screen
        if (other.gameObject.CompareTag("Finish"))
        {
            source.PlayOneShot(winSound);
            eventsManager.DisplayWinScreen();
        }
    }
}
