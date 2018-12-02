using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour {

    public GameObject[] objects = new GameObject[16];
    //public GameObject test;
    public Material unlit;
    public Material lit;
    private int[] order = new int[9];
    private bool active = false;

    private float time;
    private int pointInOrder;
    private int gameIterations;

	// Use this for initialization
	void Start () {
        resetObjects();
    }
	//TODO: dynamic game iterations
    //TODO: state machine
	// Update is called once per frame
	void Update ()
    {
		if(active)
        {
            //game code here
            if((Time.realtimeSinceStartup - time) > 5)
            {
                time = Time.realtimeSinceStartup;
                resetObjects();
                if (pointInOrder >= order.Length) generateOrder();
                objects[order[pointInOrder++]].GetComponent<MeshRenderer>().material = lit;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
            generateOrder();
            time = Time.realtimeSinceStartup;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
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
