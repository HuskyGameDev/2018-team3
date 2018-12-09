using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourAreaTrigger : MonoBehaviour {
	
	private bool gotKey = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter(Collider other)
    {
		GameManager gameManager = FindObjectOfType<GameManager>();
        if (other.tag == "Player" && !gotKey)
        {
			gotKey = true;
            gameManager.AddOneKeyFragment();
        }
    }
}
