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

    void Start ()
    {
        startPosition = transform.position;
        counter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TimeCounter>();

        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        source = manager.gameSoundsSource1;
        receiveDMGSound = manager.playerReceiveDMGSound;
    }
	
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            source.PlayOneShot(receiveDMGSound);
            transform.position = transform.position + new Vector3(startPosition.x - transform.position.x, startPosition.y - transform.position.y, 0);
            counter.counterValue.text = "" + 0;
            counter.SetTimer();
        }
    }
}
