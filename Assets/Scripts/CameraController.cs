using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target; // what camera should follow
	public Vector3 offset; // how far away from player we should be
	public bool useOffset; // set specific offset values for camera
	public float rotateSpeed; // how fast camera rotates around player
	public Transform pivot;
	public float maxViewAngle;
	public float minViewAngle;
	public bool invertY;

	// Use this for initialization
	void Start () {
		if(!useOffset) {
			offset = target.position - transform.position;
		}
		rotateSpeed = 2.5f;
		maxViewAngle = 45f;
		minViewAngle = -45f;

		// move pivot to player and make pivot child of player
		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;

		// hide cursor
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // get X pos of mouse and rotate to target
        float xJoystick = Input.GetAxis("Mouse X");
        Debug.Log(xJoystick);
        
        float horizontal;
        if (Mathf.Abs(xJoystick) < 0.25f) // otherwise camera will drift
        {
            horizontal = 0.0f;
        }
        else
        {
            horizontal = xJoystick * rotateSpeed;
        }

        target.Rotate(0, horizontal, 0);

        // get y pos of mouse and rotate the pivot
        float yJoystick = Input.GetAxis("Mouse Y");

        float vertical;
        if (Mathf.Abs(yJoystick) < 0.25f) // otherwise camera will drift
        {
            vertical = 0.0f;
        }
        else
        {
            vertical = yJoystick * rotateSpeed;
        }

        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }


        // Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
			pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
		}
		if(pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
			pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
		}

		// move camera based on current rotation of target and original offset
		float yAngle = target.eulerAngles.y;
		float xAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
		transform.position = target.position - (rotation * offset);

		// don't let player move camera under world
		if(transform.position.y < target.position.y) {
			transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
		}

		// camera looks at player
		transform.LookAt(target);
	}
}
