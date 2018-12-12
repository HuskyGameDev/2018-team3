using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemTileCollider : MonoBehaviour {

    private MemoryGame master;
    private int slaveID;

	// Use this for initialization
	void Start () {
        master = GameObject.Find("MemoryGameBounds").GetComponent<MemoryGame>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            master.receiveInput(slaveID);
        }
    }

    public void setID(int ID)
    {
        slaveID = ID;
    }

    public void setMaterial(Material m)
    {
        GetComponent<MeshRenderer>().material = m;
    }
}
