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
		moveSpeed = 10;
		jumpForce = 15;
		gravityScale = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
		// jump logic
		if(controller.isGrounded) {
			if(Input.GetButtonDown("Jump")) {
				moveDirection.y = jumpForce;
			} else {
				// fall off ledges smoothly
				moveDirection.y -= Physics.gravity.y * Time.deltaTime * gravityScale;
			}
		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
	}
}
