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

	// Use this for initialization
	void Start () {
        resetObjects();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(active)
        {
            //game code here
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
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
