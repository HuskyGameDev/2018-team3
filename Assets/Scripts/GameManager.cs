using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int currentCoins = 0;
    public int currentHearts = 3;
    public int current1Ups = 4;

    public Text coinText;
    public Text heartText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
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
        coinText.text = "Coins: " + coins;
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
        currentHearts = hearts;
        heartText.text = "Hearts: " + hearts;
    }

    public void PickUpOneHeart()
    {
        SetHearts(currentHearts + 1);
    }

    public int GetHearts()
    {
        return currentHearts;
    }
}
