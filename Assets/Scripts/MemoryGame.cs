using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour {

    /* Public variables for use in editor */
    public GameObject[] objects = new GameObject[16];
    public Material unlit;
    public Material lit;

    /* Variables for keeping tabs of the game's general state */
    private float time;
    enum State { inactive, initialize, display, player, done };
    private State state = State.inactive;
    private int[] order = new int[9];

    /* Variables for keepting tabs of game's state during initialization */

    /* Variables for keeping tabs of game's state while displaying current order */
    private int pointInOrder;
    private float delay = 1;
     
    /* Variables for player's current progress while waiting for player input*/
    private int[] playerInputs = new int[9];
    private int inputsCount;
    private int expectedInputs;

	// Use this for initialization
	void Start () {
        resetObjects();
    }

	// Update is called once per frame
	void Update ()
    {
		switch(state)
        {
            case State.inactive: //player has not entered game area
                break;
            case State.initialize: //player has entered game area, initialize game
                //TODO: display text
                break;
            case State.display: //light up the tiles in a specified order
                //TODO: light up dynamic sequence of tiles over time
                if((Time.realtimeSinceStartup - time) > 5)
                {
                    time = Time.realtimeSinceStartup;
                    resetObjects();
                    if (pointInOrder >= order.Length) generateOrder();
                    objects[order[pointInOrder++]].GetComponent<MeshRenderer>().material = lit;
                }
                break;
            case State.player: //await player input
                //TODO: link slave tiles to master
                //TODO: check player input
                break;
            case State.done: //player completed game and received key
                break;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (state != State.done) state = State.initialize;
            generateOrder();
            time = Time.realtimeSinceStartup;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (state != State.done) state = State.inactive;
            resetObjects();
        }
    }

    private void resetObjects()
    {
        foreach (GameObject g in objects)
        {
            g.GetComponent<MeshRenderer>().material = unlit;
        }
    }

    private void generateOrder()
    {
        pointInOrder = 0;
        for (int i = 0; i < order.Length; i++)
        {
            int r = Random.Range(0, 15);
            while (i > 0 && r == order[i - 1])
            {
                r = Random.Range(0, 15);
            }
            order[i] = r;
        }
    }
}
