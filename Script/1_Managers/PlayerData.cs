using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerData
{
    public bool HasSaveData = false;
    Dictionary<StatSpecies,StatBase> saveStats;
    Dictionary<ItemType, Item> equippedItems;
    int souls;

    public PlayerData()
    {
        saveStats = new Dictionary<StatSpecies, StatBase>();
        equippedItems = new Dictionary<ItemType, Item>();
    }
    public void Save()
    {
        if (Managers.Game.player == null)
        {
            Debug.LogAssertion("There's no player instance in Managers");
            return;
        }

        if (HasSaveData)
        {
            saveStats.Clear();
            equippedItems.Clear();
        }
        SavePlayerStat(); // default stat + increased stat
        SavePlayerItem(); // equipments + plus stat
        HasSaveData = true;
    }

    void SavePlayerStat()
    {
        PlayerStatHandler stats = Managers.Game.player.StatHandler;
        
        saveStats.Add(StatSpecies.LV, stats.GetStat<int>(StatSpecies.LV));
        saveStats.Add(StatSpecies.Name, stats.GetStat<string>(StatSpecies.Name));
        saveStats.Add(StatSpecies.HP, stats.GetStat<int>(StatSpecies.HP));
        saveStats.Add(StatSpecies.MaxHP, stats.GetStat<int>(StatSpecies.MaxHP));
        saveStats.Add(StatSpecies.ATKPower, stats.GetStat<int>(StatSpecies.ATKPower));
        saveStats.Add(StatSpecies.Exp, stats.GetStat<int>(StatSpecies.Exp));
        saveStats.Add(StatSpecies.MaxExp, stats.GetStat<int>(StatSpecies.MaxExp));
        saveStats.Add(StatSpecies.HPLevel, stats.GetStat<int>(StatSpecies.HPLevel));
        saveStats.Add(StatSpecies.ATKPowerLevel, stats.GetStat<int>(StatSpecies.ATKPowerLevel));
        saveStats.Add(StatSpecies.ATKRateLevel, stats.GetStat<int>(StatSpecies.ATKRateLevel));
        saveStats.Add(StatSpecies.SpeedLevel, stats.GetStat<int>(StatSpecies.SpeedLevel));
        
        saveStats.Add(StatSpecies.ATKRate, stats.GetStat<float>(StatSpecies.ATKRate));
        saveStats.Add(StatSpecies.Speed, stats.GetStat<float>(StatSpecies.Speed));
    }

    void SavePlayerItem()
    {
        PlayerInventory inventory = Managers.Game.player.Inventory;

        equippedItems.Add(ItemType.Weapon,inventory.GetEquippedItem(ItemType.Weapon));
        equippedItems.Add(ItemType.Armor,inventory.GetEquippedItem(ItemType.Armor));
        equippedItems.Add(ItemType.Accessory,inventory.GetEquippedItem(ItemType.Accessory));

        souls = inventory.soulCount;
    }

    public void Load()
    {
        if (!HasSaveData)
            return;
        LoadPlayerStats();
        LoadPlayerItems();
    }

    void LoadPlayerStats()
    {
        PlayerStatHandler stats = Managers.Game.player.StatHandler;
        stats.GetStat<int>(StatSpecies.LV).value = ((Stat<int>)saveStats[StatSpecies.LV]).value;
        stats.GetStat<int>(StatSpecies.HP).value = ((Stat<int>)saveStats[StatSpecies.HP]).value;
        stats.GetStat<int>(StatSpecies.MaxHP).value = ((Stat<int>)saveStats[StatSpecies.MaxHP]).value;
        stats.GetStat<int>(StatSpecies.ATKPower).value = ((Stat<int>)saveStats[StatSpecies.ATKPower]).value;
        stats.GetStat<int>(StatSpecies.Exp).value = ((Stat<int>)saveStats[StatSpecies.Exp]).value;
        stats.GetStat<int>(StatSpecies.MaxExp).value = ((Stat<int>)saveStats[StatSpecies.MaxExp]).value;
        stats.GetStat<int>(StatSpecies.HPLevel).value = ((Stat<int>)saveStats[StatSpecies.HPLevel]).value;
        stats.GetStat<int>(StatSpecies.ATKPowerLevel).value = ((Stat<int>)saveStats[StatSpecies.ATKPowerLevel]).value;
        stats.GetStat<int>(StatSpecies.ATKRateLevel).value = ((Stat<int>)saveStats[StatSpecies.ATKRateLevel]).value;
        stats.GetStat<int>(StatSpecies.SpeedLevel).value = ((Stat<int>)saveStats[StatSpecies.SpeedLevel]).value;
        
        stats.GetStat<float>(StatSpecies.ATKRate).value = ((Stat<float>)saveStats[StatSpecies.ATKRate]).value;
        stats.GetStat<float>(StatSpecies.Speed).value = ((Stat<float>)saveStats[StatSpecies.Speed]).value;
    }

    void LoadPlayerItems()
    {
        PlayerInventory inventory = Managers.Game.player.Inventory;

        foreach (var i in equippedItems)
        {
            if(i.Value != null)
                inventory.Equip(i.Value);
        }

        inventory.soulCount = souls;
    }
}