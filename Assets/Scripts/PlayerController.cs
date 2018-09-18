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
		jumpForce = 200;
		gravityScale = 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
		if(Input.GetButtonDown("Jump")) {
			moveDirection.y = jumpForce;
		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
		controller.Move(moveDirection * Time.deltaTime);
	}
}
