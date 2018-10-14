using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimator : MonoBehaviour {

    private float startingY;
    private int sign = 1;
    float RotationSpeed = 120f;
    float TranslationSpeed = 0.5f;

    // Use this for initialization
    void Start () {
        startingY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * RotationSpeed);
        transform.Translate(0, Time.deltaTime * sign * TranslationSpeed, 0);

        if (Math.Abs(transform.position.y - startingY) > 0.2)
        {
            sign = -sign;
        }
    }
}
