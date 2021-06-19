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
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI skipGems;
    public float timer;
    float hours;
    float minutes;

    //Rewards
    public int GoldReward;
    public int GemReward;
    private void Awake()
    {
        equipped = started = false;
        skipGems.enabled = false;
        timerText.enabled = false;
    }

    private void Update()
    {
        if (equipped && started)
        {
            float hours = timer / 3600;
            float minutes = timer / 60;
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = Mathf.FloorToInt(hours) + "h" + Mathf.FloorToInt(minutes / Mathf.CeilToInt(hours)) + "m" + Mathf.FloorToInt(timer % 60) + "s";
                skipGems.text = "GEMS: " + Mathf.CeilToInt(minutes / 10);
            }
            else if (timer < 0) {
                timer = 0;
                UnEquipSlot();
                ChestSpawner.FreeSlot();
            }
        }
        else if (equipped && !started)
        {
            float hours = timer / 3600;
            float minutes = timer / 60;
            if (Mathf.FloorToInt(hours) != 0)
                timerText.text = "Locked: " + hours + "h";
            else timerText.text = "Locked " + minutes + "m";
            skipGems.text = "";
        }
        
    }

    private void UnEquipSlot()
    {
        //add coins and gems and free the slot
        skipTime.image.color = Color.grey;
        timerText.text = "";
        skipGems.text = "";
        equipped = false;
    }

    public void enableText() {
        skipGems.enabled = true;
        timerText.enabled = true;
    }
    public void StartOpening() {
        started = true;
    }
}
