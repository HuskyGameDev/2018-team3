﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.RemoveHearts(1);

            gameManager.ShowDialog("hahahaha! I am Foxtail and you are a stupid tiger for trying to come out in my jungle!");
        }
    }
}
