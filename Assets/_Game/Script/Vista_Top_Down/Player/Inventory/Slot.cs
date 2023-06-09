using System;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    InventoryM inventory;
    public GameObject item;

    public int countStack;
    public bool isFull;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryM>();
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            Destroy(child.gameObject);
            countStack--;
            if (countStack <= 0)
            {
                item = null;
                isFull = false;
                countStack = 0;
            }
        }
    }
}
