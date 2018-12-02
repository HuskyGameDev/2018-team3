using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int currentCoins = 0;
    public int currentHearts = 3;
    public int current1Ups = 4;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public Text CoinText;
    public Text OneUpText;

    private int heart1BlinkState = 0;
    private int heart2BlinkState = 0;
    private int heart3BlinkState = 0;

    public float HeartBlinkRate = 0.1f;
    public int HeartBlinkCount = 15;

    // Use this for initialization
    void Start () {
        if (HeartBlinkCount % 2 == 0)
        {
            HeartBlinkCount++; // must be an odd number or it won't work. 
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetOneUps(int oneups) {
		current1Ups = oneups;
		OneUpText.text = current1Ups.ToString() + " x ";
	}
	
	public void RemoveOneUp() {
		SetOneUps(current1Ups - 1);
	}
	
	public void AddOneUp() {
		SetOneUps(current1Ups + 1);
	}
	
	public int GetOneUp() {
		return current1Ups;
	}

    public void RemoveCoins(int coins)
    {
        SetCoins(currentCoins - coins);
    }

    public void AddCoins(int coins)
    {
        SetCoins(currentCoins + coins);
    }

    public void SetCoins(int coins)
    {
        currentCoins = coins;
        CoinText.text = "x " + coins.ToString().PadLeft(3, '0');
    }

    public void PickUpOneCoin()
    {
        SetCoins(currentCoins + 1);
    }

    public int GetCoins()
    {
        return currentCoins;
    }

    public void RemoveHearts(int hearts)
    {
        SetHearts(currentHearts - hearts);
    }

    public void AddHearts(int hearts)
    {
        SetHearts(currentHearts + hearts);
    }

    public void SetHearts(int hearts)
    {
        int previousHearts = currentHearts;
        currentHearts = hearts;
        if (previousHearts < currentHearts)
        {
            Heart1.SetActive(hearts >= 1);
            Heart2.SetActive(hearts >= 2);
            Heart3.SetActive(hearts >= 3);
        }
        else if (previousHearts > currentHearts)
        {
            if (currentHearts < 3 && previousHearts >= 3)
            {
                StartBlink(3);
            }
            if (currentHearts < 2 && previousHearts >= 2)
            {
                StartBlink(2);
            }
            if (currentHearts < 1 && previousHearts >= 1)
            {
				// we don't actually want the last heart to blink away, because the player died
                //StartBlink(1);
            }
        }
    }

    public void PickUpOneHeart()
    {
        SetHearts(currentHearts + 1);
    }

    public int GetHearts()
    {
        return currentHearts;
    }

    private void StartBlink(int heart)
    {
        if (heart == 1 && heart1BlinkState > 0 || heart == 2 && heart2BlinkState > 0 || heart == 3 && heart3BlinkState > 0)
        {
            return;
        }
        
        InvokeRepeating("ToggleHeart" + heart, 0.0f, HeartBlinkRate);
    }

    private void ToggleHeart1()
    {
        Heart1.SetActive(!Heart1.activeSelf);
        heart1BlinkState++;
        if (heart1BlinkState == HeartBlinkCount)
        {
            heart1BlinkState = 0;
            CancelInvoke("ToggleHeart1");
        }
    }

    private void ToggleHeart2()
    {
        Heart2.SetActive(!Heart2.activeSelf);
        heart2BlinkState++;
        if (heart2BlinkState == HeartBlinkCount)
        {
            heart2BlinkState = 0;
            CancelInvoke("ToggleHeart2");
        }
    }

    private void ToggleHeart3()
    {
        Heart3.SetActive(!Heart3.activeSelf);
        heart3BlinkState++;
        if (heart3BlinkState == HeartBlinkCount)
        {
            heart3BlinkState = 0;
            CancelInvoke("ToggleHeart3");
        }
    }
}
