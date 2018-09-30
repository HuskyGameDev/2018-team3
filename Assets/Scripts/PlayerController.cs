using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public CharacterController controller;
	public float moveSpeed;
	public float jumpForce;
	public float gravityScale;

	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		moveSpeed = 5f;
		jumpForce = 15f;
		gravityScale = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		// set movement
		//NOTE: Use GetAxisRaw to remove "sliding" after movement
		float prevY = moveDirection.y; // store y value temp
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + 
				(transform.right * Input.GetAxis("Horizontal"));
		moveDirection = moveDirection * moveSpeed;
		moveDirection.y = prevY;

        // jump logic
        if (controller.isGrounded) {
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump")) {
				moveDirection.y = jumpForce;
			}
		}

		// apply gravity
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

		// apply movement
		controller.Move(moveDirection * Time.deltaTime);
	}
}
