using System;
using UnityEngine;
using UnityEngine.UI;

public class ChestSpawner : MonoBehaviour
{
    public Chest[] chests;
    public Button spawnButton;
    public GameObject[] chestSlot;
    private int empty;

    // Start is called before the first frame update
    private void Awake()
    {
        chestSlot = new GameObject[4];
        empty = 0;
    }
    void Start()
    {
        spawnButton.onClick.AddListener(SpawnChest);
    }

    private void SpawnChest()
    {
        Debug.Log("Button clicked");
        int spawnNumber = UnityEngine.Random.Range(0,chests.Length);
        Chest newChest = chests[spawnNumber];
        //begin here tomorrow
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
