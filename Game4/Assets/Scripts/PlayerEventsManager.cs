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
        startPosition = transform.position;
        counter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TimeCounter>();

        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        source = manager.gameSoundsSource1;
        receiveDMGSound = manager.playerReceiveDMGSound;
        deathSound = manager.playerDeathSound;
        winSound = manager.levelCompletedSound;

        eventsManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameplayEventsManager>();
    }
	
	void Update () {
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(eventsManager.lives>1)
            {
                source.PlayOneShot(receiveDMGSound);
            }
            else
            {
                source.PlayOneShot(deathSound);
            }
            transform.position = transform.position + new Vector3(startPosition.x - transform.position.x, startPosition.y - transform.position.y, 0);
            counter.SetTimer();
            eventsManager.DealDMG();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            source.PlayOneShot(winSound);
            eventsManager.DisplayWinScreen();
        }
    }
}
