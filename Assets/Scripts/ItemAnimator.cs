using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimator : MonoBehaviour {

    private float startingX, startingY, startingZ;
    private int signX = 1, signY = 1, signZ = 1;
    public float RotationSpeedX, RotationSpeedY, RotationSpeedZ;
    public float TranslationSpeedX, TranslationSpeedY, TranslationSpeedZ;
    public float TranslationDistanceX, TranslationDistanceY, TranslationDistanceZ;

    // Use this for initialization
    void Start () {
        startingX = transform.position.x;
        startingY = transform.position.y;
        startingZ = transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * RotationSpeedY);
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * RotationSpeedX);
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * RotationSpeedZ);
        transform.Translate(Time.deltaTime * signX * TranslationSpeedX, 
            Time.deltaTime * signY * TranslationSpeedY, 
            Time.deltaTime * signZ * TranslationSpeedZ);
        if (Math.Abs(transform.position.x - startingX) > TranslationDistanceX)
        {
            signX = -signX;
        }

        if (Math.Abs(transform.position.y - startingY) > TranslationDistanceY || transform.position.y < 0)
        {
            signY = -signY;
        }

        if (Math.Abs(transform.position.z - startingZ) > TranslationDistanceZ)
        {
            signZ = -signZ;
        }
    }
}
