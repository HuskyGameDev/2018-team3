using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAreaDialogManager : MonoBehaviour
{

    private GameManager gameManager;
    private int dialogStep = -1;

    // Use this for initialization
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (dialogStep)
        {
            case 0:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Welcome to Temple of the Sun, Reggie! Before you get started, let me teach you the controls.");
                    dialogStep++;
                }
                break;
            case 1:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Press WASD or use the left joystick to move around. Pressing SHIFT or LJ will make you run.");
                    dialogStep++;
                }
                break;
            case 2:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Use SPACE or A on the controller to jump. While in the air, press again to double jump.");
                    dialogStep++;
                }
                break;
            case 3:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.RemoveHearts(1);
                    gameManager.ShowDialog("Collect a heart by passing through it to replace lost health.");
                    dialogStep++;
                }
                break;
            case 4:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Coins are spread out in the jungle. See how many you can find!");
                    dialogStep++;
                }
                break;
            case 5:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Good luck, Reggie!");
                    dialogStep = -1;
                }
                break;
            case 6:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Whoops, allow me to introduce myself. I'm Foxtail. Remember me? From all that time ago?");
                    //dialogStep++;
                }
                break;
            case 7:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("You don't? Oh. Well let me refresh your memory. I'm your worst nightmare.");
                    dialogStep++;
                }
                break;
            case 8:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("I'll make sure you never get that treasure hidden inside the temple!");
                    dialogStep++;
                }
                break;
            case 9:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("You'd have to get all five hidden key fragments first to unlock the gate and -");
                    dialogStep++;
                }
                break;
            case 10:
                if (!gameManager.IsShowingDialog())
                {
                    gameManager.ShowDialog("Oh. I shouldn't have told you that.");
                    dialogStep = -1;
                }
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        dialogStep = 0;
    }

    public void OnTriggerExit(Collider other)
    {
        dialogStep = 6;
    }
}
