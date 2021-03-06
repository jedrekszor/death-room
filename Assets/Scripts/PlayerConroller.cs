﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerConroller : MonoBehaviour {
    
    private DeathManager dm;
    public GameObject player;
    public GameObject blood;
    public GameObject leg1;
    public GameObject leg2;
    public GameObject laserCut;
    public GameObject _shot;
    public AudioClip smash;
   

    public static List<GameObject> deadBodies = new List<GameObject>();

    public GameObject start;
    public GameObject restart;

    AudioSource source;

    bool isDead = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        onRestart();
        
    }

    private void Update() {
        if(isDead) enableResetGame();
    }
    
    public void Kaboom()
    {
        //deadBodies.Add(Instantiate(leg1, transform.position, Quaternion.identity));
        //deadBodies.Add(Instantiate(leg2, new Vector3(transform.position.x-2, transform.position.y, transform.position.z), Quaternion.identity));
        deadBodies.Add(Instantiate(blood, transform.position, Quaternion.identity));
        transform.position = new Vector2(100, 100);
        isDead = true;
        DeathCounter.score++;
        
    }

    public void Lazers()
    {
        //deadBodies.Add(Instantiate(laserCut, transform.position, Quaternion.identity));
        deadBodies.Add(Instantiate(blood, transform.position, Quaternion.identity));
        transform.position = new Vector2(100, 100);
        isDead = true;
        DeathCounter.score++;
    }

    public void Smash()
    {
        deadBodies.Add(Instantiate(blood, transform.position, Quaternion.identity));
        source.clip = smash;
        source.PlayOneShot(source.clip);
        
        transform.position = new Vector2(100, 100);
        isDead = true;
        DeathCounter.score++;
    }

    public void Fall()
    {
        transform.position = new Vector2(100, 100);
        isDead = true;
        DeathCounter.score++;
    }

    public void shot()
    {
        //deadBodies.Add(Instantiate(_shot, transform.position, Quaternion.identity));
        deadBodies.Add(Instantiate(blood, transform.position, Quaternion.identity));
        transform.position = new Vector2(100, 100); 
        isDead = true;
        DeathCounter.score++;
    }

    void enableResetGame(){
        //opcja resetu na przycisk?
        start.SetActive(true);
        restart.SetActive(true);
        
    }

    public static void deleteDeadBodies(){
        for(int i = 0; i < deadBodies.Count; i++)
            Destroy(deadBodies[i]);
        deadBodies = new List<GameObject>(); 
    }

    public void onRestart()
    {
        Debug.Log("restart");
        start.SetActive(false);
        restart.SetActive(false);
        isDead = false;
            
        transform.position = new Vector2(1.5f, 2.2f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //tilesPlacement.restoreTiles();
        TilesPlacemant.restoreTiles();
        //reset punktacji w gui
    }
}

