﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject SpawnPoint;
    public GameObject Player;

    public float firerate = 0.5f;
    public float velocity = 15f;
    public float rotationOffset = 0.2f;
    public float ammunition = 10;

    bool flag = true;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Player.transform.position - transform.position; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

        if (flag && ammunition >= 0)
        {
            direction.Normalize();
            GameObject shot = (GameObject)Instantiate(Bullet, SpawnPoint.transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = transform.right * velocity;
            StartCoroutine(Cooldown());
            Destroy(shot, 5);
            ammunition--;
        }
    }

    IEnumerator Cooldown()
    {
        flag = false;

        yield return new WaitForSeconds(firerate);
        flag = true;
    }
}