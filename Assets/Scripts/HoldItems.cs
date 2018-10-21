﻿ using UnityEngine;
 using System.Collections;
 
 public class HoldItems : MonoBehaviour {
 
	public float throwSpeed = 10;
	public bool canHold = true;
	public GameObject ball;
	public Transform guide;
 
	void Update()
	{
		float distance;
		if (Input.GetButtonDown("Grab") && !canHold) {
			Drop();
			Debug.Log("Throwing " + ball);
		} else if (Input.GetButtonDown("Grab")) {
			distance = Vector3.Distance(ball.transform.position, guide.transform.position);
			Debug.Log("Attempting to pick up " + ball + ", distance = " + distance);
			if (distance < 1.5f) {
				Pickup();
			}
		}
  
		if (!canHold && ball)
			ball.transform.position = guide.position;       
   }
 
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "ball")
			if (!ball) // if we don't have anything holding
				ball = col.gameObject;
	}
 
	void OnTriggerExit(Collider col)
	{
        if (col.gameObject.tag == "ball") {
			if (canHold)
				ball = null;
		}
	}
 
	private void Pickup()
	{
		if (!ball)
			return;
 
         // set the object parent to our guide empty object.
         ball.transform.SetParent(guide);
 
         // set gravity to false while holding it
         ball.GetComponent<Rigidbody>().useGravity = false;
 
         // apply the same rotation our main object has.
         //ball.transform.localRotation = transform.rotation;
		 
         // re-position the ball on our guide object 
         ball.transform.position = guide.position;
 
         canHold = false;
     }
 
    private void Drop()
	 {
		 if (!ball)
			 return;
 
         // set our Gravity to true again.
         ball.GetComponent<Rigidbody>().useGravity = true;
		  
         // apply velocity on throwing
         guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
 
         // unparent our ball
         guide.GetChild(0).parent = null;
         
		 canHold = true;
     }
 }//class