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
    private GameManager gameManager;

    /* Variables for keepting tabs of game's state during initialization */
    private int dialogStep = 0;

    /* Variables for keeping tabs of game's state while displaying current order */
    private int[] order = new int[9];
    private int pointInOrder;
    private const float delay = 1;

    /* Variables for player's current progress while waiting for player input*/
    private int[] playerInputs = new int[9];
    private int inputsCount = 0;
    private int expectedInputs = 3;
    private int failures;

    // Use this for initialization
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.PickUpOneCoin();
        for (int i = 0; i < objects.Length; i++)
        {
            MemTileCollider m = objects[i].GetComponent<MemTileCollider>();
            m.setID(i);
        }
        resetObjects();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.inactive: //player has not entered game area
                break;
            case State.initialize: //player has entered game area, initialize game
                initialize();
                break;
            case State.display: //light up the tiles in a specified order
                display();
                break;
            case State.player: //await player input
                player();
                break;
            case State.done: //player completed game and received key
                break;
        }
    }

    /* Collision handlers */
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
            if (state != State.done)
            {
                state = State.inactive;
                resetObjects();
            }
        }
    }

    /* Master state managing methods */
    private void initialize()
    {
        switch(dialogStep)
        {
            case 0:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Watch the the order that the tiles light up in. Light them up in the same order to get a key fragment.");
                    dialogStep++;
                }
                break;
            case 1:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Screw up and you'll have to start over! This one took me 10 tries.");
                    dialogStep++;
                }
                break;
            case 2:
                if(!gameManager.IsShowingDialog())
                {
                    //dialog is done, move to gameplay
                    dialogStep = -1;
                    state = State.display;
                }
                break;
        }
    }

    private void display()
    {
        if(expectedInputs > order.Length)
        {
            //game is done
            if (!gameManager.IsShowingDialog())
            {
                gameManager.ShowDialog("Drat! You may have won this time, but you'll never get the treasure!");
            }
            gameManager.AddOneKeyFragment();
            state = State.done;
            return;
        }
        if ((Time.realtimeSinceStartup - time) > delay)
        {
            time = Time.realtimeSinceStartup;
            resetObjects();
            if (pointInOrder >= expectedInputs)
            {
                pointInOrder = 0;
                state = State.player;
            }
            else
            {
                objects[order[pointInOrder++]].GetComponent<MeshRenderer>().material = lit;
            }
        }
    }

    private void player()
    {
        if(expectedInputs == inputsCount)
        {
            bool correct = true;
            for(int i = 0; i < expectedInputs; i++)
            {
                if (order[i] != playerInputs[i]) correct = false;
            }
            if (correct)
            {
                if ((Time.realtimeSinceStartup - time) > delay)
                {
                    expectedInputs++;
                    time = Time.realtimeSinceStartup;
                    state = State.display;
                    resetObjects();
                    inputsCount = 0;
                }
            }
            else
            {
                failures++;
                if(failures == 11 && !gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Wow! I did better than you're doing! You know you can leave and come back for a different order, right?");
                }
                time = Time.realtimeSinceStartup;
                state = State.display;
                resetObjects();
                inputsCount = 0;
            }
            
        }
    }

    /* Helper state managing methods */
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

    /* Public methods */
    public void receiveInput(int slaveID)
    {
        if (state == State.player && inputsCount < expectedInputs)
        {
            playerInputs[inputsCount++] = slaveID;
            MemTileCollider m = objects[slaveID].GetComponent<MemTileCollider>();
            m.setMaterial(lit);
            time = Time.realtimeSinceStartup;
            //TODO: add auditory feedback?
        }
    }
}
