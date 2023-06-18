using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    public static UnityAction<InventorySystem, int> OnPlayerInventoryChanged;

    private void Start()
    {
        SaveGameManager.data.playerInventory = new InventorySaveData(primaryInventorySystem);
    }

    protected override void LoadInventory(SaveData data)
    {
        // Controlla i dati salvati per l'inventario del giocatore e, se esiste, caricalo.
        if (data.playerInventory.InvSystem != null)
        {
            this.primaryInventorySystem = data.playerInventory.InvSystem;
            OnPlayerInventoryChanged?.Invoke(primaryInventorySystem, 0);
        }
    }

    void Update()
    {
        // COMMENTA QUESTA RIGA QUI SOTTO PER TOGLIERE IL SECONDO INVENTARIO
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            OnPlayerInventoryChanged?.Invoke(primaryInventorySystem, offset);
        }
    }

    public bool AddToInventory(InventoryItemData data, int amount)
    {
        if (primaryInventorySystem.AddToInventory(data, amount))
        {
            return true;
        }

        return false;
    }
}
