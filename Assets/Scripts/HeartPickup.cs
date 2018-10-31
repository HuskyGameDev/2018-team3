using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour {

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
            if (gameManager.GetHearts() < 3)
            {
                Debug.Log("Do Heart Pickup");
                gameManager.PickUpOneHeart();
                Destroy(gameObject);
            }
        }
    }
}
