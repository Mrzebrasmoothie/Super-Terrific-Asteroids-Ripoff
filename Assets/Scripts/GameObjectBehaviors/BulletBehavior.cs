﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBehavior : MonoBehaviour {

    public bool prideBullet;
    public float speed;
    public float destroyTime = 2f;
    public Vector3 startRotation;
    public Color[] prideColors = new Color[7];
    public ParticleSystem burst;

    void Awake () {
        Invoke("destroyThis", destroyTime);
        if (prideBullet) {
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = prideColors[GameManager.currentPrideColor++];
            if (GameManager.currentPrideColor == 6) {
                GameManager.currentPrideColor = 0;
            }
        }
	}
	
	void FixedUpdate () {
        transform.Translate(new Vector3(0, 0, speed));
    }

    private void destroyThis()
    {
        Instantiate(burst, transform.position, transform.rotation, null);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") {
            Instantiate(burst, transform.position, transform.rotation, null);
        }
    }
}
