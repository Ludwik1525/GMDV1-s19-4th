using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	GameObject gameManager;
	// Use this for initialization
	void Awake () {
		if(GameManager.instance == null){
			Instantiate(gameManager);
		}
	}
	

}
