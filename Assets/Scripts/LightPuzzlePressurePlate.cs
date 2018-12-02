using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzlePressurePlate : MonoBehaviour
{

    public GameObject top;
    public GameObject right;
    public GameObject bottom;
    public GameObject left;
    public bool state = false;
    public bool changeColor = true;

    private Material mat;
    private bool isColliding = false;

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (state)
        {
            state = false;
            ToggleState();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isColliding) return;
            isColliding = true;

            transform.Translate(0, -.1f, 0);
            ToggleState();
            if (top != null)
            {
                top.GetComponent<LightPuzzlePressurePlate>().ToggleState();
            }
            if (right != null)
            {
                right.GetComponent<LightPuzzlePressurePlate>().ToggleState();
            }
            if (bottom != null)
            {
                bottom.GetComponent<LightPuzzlePressurePlate>().ToggleState();
            }
            if (left != null)
            {
                left.GetComponent<LightPuzzlePressurePlate>().ToggleState();
            }
        }
    }

    public bool GetState()
    {
        return state;
    }

    public void SetState(bool state)
    {
        this.state = state;
        if (changeColor)
            mat.color = state ? Color.yellow : new Color(54f / 255, 113f / 255, 64f / 255);
    }

    private void ToggleState()
    {
        state = !state;
        if (changeColor)
            mat.color = state ? Color.yellow : new Color(54f / 255, 113f / 255, 64f / 255);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.Translate(0, .1f, 0);
        isColliding = false;
    }
}
