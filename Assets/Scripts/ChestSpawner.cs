using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSpawner : MonoBehaviour
{
    public Chest[] chests;
    public Button spawnButton;
    public ChestSlot[] chestSlot;
    private static int empty;
    private Queue<ChestSlot> slotQueue;
    private static bool isProcessing, isEmpty;


    // Start is called before the first frame update
    private void Awake()
    {
        slotQueue = new Queue<ChestSlot>();
        empty = 0;
        isProcessing  = false;
        isEmpty = true;
    }
    void Start()
    {
        spawnButton.onClick.AddListener(SpawnChest);
    }

    private void SpawnChest()
    {
        int spawnNumber = UnityEngine.Random.Range(0,chests.Length);
        Chest newChest = chests[spawnNumber];
        ChestSlot slot;
        int emptyslot = findEmpty();
        if (empty < chestSlot.Length)
        {
            slotQueue.Enqueue(chestSlot[emptyslot]);
            isEmpty = false;
            slot = chestSlot[emptyslot];
            slot.enableText();
            slot.equipped = true;
            slot.GemReward = UnityEngine.Random.Range(newChest.gemMin, newChest.gemMax + 1);
            slot.GoldReward = UnityEngine.Random.Range(newChest.coinsMin, newChest.coinsMax + 1);
            slot.skipTime.image.color = newChest.color;
            slot.timer = newChest.Timer * 60;
            empty++;
        }
        else {
            Debug.Log("All slots full");
        }
        
    }

    private int findEmpty()
    {
        for (int i = 0; i < chestSlot.Length;i++) {
            if (chestSlot[i].equipped == false) return i;
        }
        return -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isProcessing && !isEmpty) {
            ChestSlot slot = slotQueue.Dequeue().GetComponent<ChestSlot>();
            slot.StartOpening();
            isProcessing = true;
        }
    }

    public static void FreeSlot() {
        ChestSpawner.isProcessing = false;
        ChestSpawner.empty--;
        Debug.Log(empty);
        if (empty == 0) isEmpty = true;
    }
}
