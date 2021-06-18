using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public bool equipped;
    public Button skipTime;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI skipGems;

    //Rewards
    public int GoldReward;
    public int GemReward;
    private void Awake()
    {
        equipped = false;
        skipGems.enabled = false;
        timer.enabled = false;
    }
}
