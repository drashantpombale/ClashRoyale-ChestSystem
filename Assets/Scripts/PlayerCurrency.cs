using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    private static int coins, gems;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gemText;

    private void Awake()
    {
        coins = 100;
        gems = 5;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ""+coins;
        gemText.text = ""+gems;
    }

    public static int playerCoins {
        get{ return coins; }
        set { coins += value; }
    }

    public static int playerGems {
        get { return gems; }
        set { gems += value; }
    }

}
