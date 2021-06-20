using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public bool equipped,started;
    public Button skipTime;
    public Image gem;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI skipGemsText;
    public int skipGems;
    public float timer;
    float hours;
    float minutes;

    //Rewards
    public int GoldReward;
    public int GemReward;
    private void Awake()
    {
        skipTime.enabled = false;
        equipped = started = false;
        skipGemsText.enabled = false;
        timerText.enabled = false;
    }

    private void Start()
    {
        skipTime.onClick.AddListener(UnEquipSlot);
    }

    private void Update()
    {
        if (equipped && started)
        {
            skipTime.enabled = true;
            float hours = timer / 3600;
            float minutes = timer / 60;
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = Mathf.FloorToInt(hours) + "h" + Mathf.FloorToInt(minutes / Mathf.CeilToInt(hours)) + "m" + Mathf.FloorToInt(timer % 60) + "s";
                skipGems = Mathf.CeilToInt(minutes / 10);
                skipGemsText.text = ""+skipGems;
                gem.gameObject.SetActive(true);
            }
            else if (timer < 0) {
                UnEquipSlot();
            }
        }
        else if (equipped && !started)
        {
            float hours = timer / 3600;
            float minutes = timer / 60;
            if (Mathf.FloorToInt(hours) != 0)
                timerText.text = "Locked: " + hours + "h";
            else timerText.text = "Locked " + minutes + "m";
            skipGemsText.text = "";
        }
        
    }

    private void UnEquipSlot()
    {
        if (timer >= 0)
        {
            if (PlayerCurrency.playerGems >= skipGems)
            {
                PlayerCurrency.playerGems = -skipGems;
            }
            else {
                Debug.Log("Not enough gems");
                return;
                    };
        }
        gem.gameObject.SetActive(false);
        timer = 0;
        skipTime.image.color = Color.white;
        timerText.text = "";
        skipGemsText.text = "";
        equipped = false;
        started = false;
        Debug.Log("Gold-" + GoldReward + "  Gems-" + GemReward);
        PlayerCurrency.playerCoins = GoldReward;
        PlayerCurrency.playerGems = GemReward;
        GoldReward = GemReward = 0;
        ChestSpawner.FreeSlot();

        skipTime.enabled = false;
    }

    public void enableText() {
        skipGemsText.enabled = true;
        timerText.enabled = true;
    }
    public void StartOpening() {
        started = true;
    }
}
