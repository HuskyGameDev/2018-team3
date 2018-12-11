using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleAreaTrigger : MonoBehaviour {

    public GameObject controllerPlate;
    private LightPuzzleManager puzzleManager;

	// Use this for initialization
	void Start () {
        puzzleManager = controllerPlate.GetComponent<LightPuzzleManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            puzzleManager.PlayerEnteredPuzzleArea();
        }
    }
}
