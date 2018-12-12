using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LightPuzzleManager : MonoBehaviour
{

    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;
    public GameObject square5;
    public GameObject square6;
    public GameObject square7;
    public GameObject square8;
    public GameObject square9;
    public GameObject square10;
    public GameObject square11;
    public GameObject square12;
    public GameObject square13;
    public GameObject square14;
    public GameObject square15;
    public GameObject square16;
    public GameObject square17;
    public GameObject square18;
    public GameObject square19;
    public GameObject square20;
    public GameObject square21;
    public GameObject square22;
    public GameObject square23;
    public GameObject square24;
    public GameObject square25;

    private LightPuzzlePressurePlate plate1;
    private LightPuzzlePressurePlate plate2;
    private LightPuzzlePressurePlate plate3;
    private LightPuzzlePressurePlate plate4;
    private LightPuzzlePressurePlate plate5;
    private LightPuzzlePressurePlate plate6;
    private LightPuzzlePressurePlate plate7;
    private LightPuzzlePressurePlate plate8;
    private LightPuzzlePressurePlate plate9;
    private LightPuzzlePressurePlate plate10;
    private LightPuzzlePressurePlate plate11;
    private LightPuzzlePressurePlate plate12;
    private LightPuzzlePressurePlate plate13;
    private LightPuzzlePressurePlate plate14;
    private LightPuzzlePressurePlate plate15;
    private LightPuzzlePressurePlate plate16;
    private LightPuzzlePressurePlate plate17;
    private LightPuzzlePressurePlate plate18;
    private LightPuzzlePressurePlate plate19;
    private LightPuzzlePressurePlate plate20;
    private LightPuzzlePressurePlate plate21;
    private LightPuzzlePressurePlate plate22;
    private LightPuzzlePressurePlate plate23;
    private LightPuzzlePressurePlate plate24;
    private LightPuzzlePressurePlate plate25;

    private LightPuzzlePressurePlate[] plates;
    private bool puzzleSolved = false;
    private int initialSelection = -1;
    private bool initialStateReset = false;
    private GameManager gameManager;
    private int dialogStep = -1;

    // Use this for initialization
    void Start()
    {
        plate1 = square1.GetComponent<LightPuzzlePressurePlate>();
        plate2 = square2.GetComponent<LightPuzzlePressurePlate>();
        plate3 = square3.GetComponent<LightPuzzlePressurePlate>();
        plate4 = square4.GetComponent<LightPuzzlePressurePlate>();
        plate5 = square5.GetComponent<LightPuzzlePressurePlate>();
        plate6 = square6.GetComponent<LightPuzzlePressurePlate>();
        plate7 = square7.GetComponent<LightPuzzlePressurePlate>();
        plate8 = square8.GetComponent<LightPuzzlePressurePlate>();
        plate9 = square9.GetComponent<LightPuzzlePressurePlate>();
        plate10 = square10.GetComponent<LightPuzzlePressurePlate>();
        plate11 = square11.GetComponent<LightPuzzlePressurePlate>();
        plate12 = square12.GetComponent<LightPuzzlePressurePlate>();
        plate13 = square13.GetComponent<LightPuzzlePressurePlate>();
        plate14 = square14.GetComponent<LightPuzzlePressurePlate>();
        plate15 = square15.GetComponent<LightPuzzlePressurePlate>();
        plate16 = square16.GetComponent<LightPuzzlePressurePlate>();
        plate17 = square17.GetComponent<LightPuzzlePressurePlate>();
        plate18 = square18.GetComponent<LightPuzzlePressurePlate>();
        plate19 = square19.GetComponent<LightPuzzlePressurePlate>();
        plate20 = square20.GetComponent<LightPuzzlePressurePlate>();
        plate21 = square21.GetComponent<LightPuzzlePressurePlate>();
        plate22 = square22.GetComponent<LightPuzzlePressurePlate>();
        plate23 = square23.GetComponent<LightPuzzlePressurePlate>();
        plate24 = square24.GetComponent<LightPuzzlePressurePlate>();
        plate25 = square25.GetComponent<LightPuzzlePressurePlate>();

        plates = new LightPuzzlePressurePlate[] { plate1, plate2, plate3, plate4, plate5, plate6, plate7, plate8, plate9, plate10,
                   plate11, plate12, plate13, plate14, plate15, plate16, plate17, plate18, plate19, plate20,
                   plate21, plate22, plate23, plate24, plate25
                 };

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialStateReset)
        {
            initialStateReset = true;

            initialSelection = new System.Random().Next(3);
            ResetBoard(initialSelection);
        }

        var success = true;
        for (int i = 0; i < plates.Length; i++)
        {
            if (plates[i].GetState())
            {
                success = false;
                break;
            }
        }

        switch(dialogStep)
        {
            case 0:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("You have discovered the light puzzle! Turn off all the lights to get a key fragment.");
                    dialogStep++;
                }
                break;
            case 1:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("If you want to reset the lights, stand on the red pressure plate.");
                    dialogStep++;
                }
                break;
            case 2:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("I'm sure you'll have to do that a lot. I doubt you can even get this key fragment.");
                    dialogStep = -1;
                }
                break;
            case 3:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Drat! You may have won this time, but you'll never get the treasure!");
                    dialogStep = -1;
                }
                break;
        }

        if (success && !this.puzzleSolved)
        {
            dialogStep = 3;
            gameManager.AddOneKeyFragment();
        }

        this.puzzleSolved = this.puzzleSolved || success;
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetBoard(initialSelection);
    }

    private void ResetBoard(int board)
    {
        for (int i = 0; i < plates.Length; i++)
        {
            plates[i].SetState(false);
        }

        if (board == 0)
        {
            plates[0].SetState(true);
            plates[6].SetState(true);
            plates[12].SetState(true);
            plates[18].SetState(true);
            plates[24].SetState(true);
        }
        else if (board == 1)
        {
            plates[1].SetState(true);
            plates[2].SetState(true);
            plates[3].SetState(true);
            plates[4].SetState(true);
            plates[8].SetState(true);
            plates[13].SetState(true);
        }
        else if (board == 2)
        {
            plates[0].SetState(true);
            plates[2].SetState(true);
            plates[5].SetState(true);
            plates[7].SetState(true);
            plates[10].SetState(true);
            plates[13].SetState(true);
            plates[14].SetState(true);
            plates[22].SetState(true);
            plates[23].SetState(true);
            plates[24].SetState(true);
        }
    }

    public void PlayerEnteredPuzzleArea()
    {
        if (puzzleSolved)
        {
            gameManager.ShowDialog("You have already solved this puzzle! Go find another key fragment somewhere else.");
        }
        else
        {
            dialogStep = 0;
        }
    }
}
