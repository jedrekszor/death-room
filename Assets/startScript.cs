﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour {
	GameObject _player;

	bool initialized = false;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) && !initialized){
			initialized = true;
			_player.GetComponent<Rigidbody2D>().isKinematic = false;
			_player.GetComponent<SpriteRenderer>().enabled = true;
			_player.transform.position = new Vector2(1.63f, 2.2f);
			gameObject.SetActive(false);
		}
		
	}
}
