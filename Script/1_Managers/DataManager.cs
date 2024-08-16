using System.Collections.Generic;

public class DataManager
{
    public int lvl = 0; 
    //public Dictionary<int,string>
    public PlayerData playerData;

     ItemManager itemManager;
    public ItemManager Item => itemManager;
    
    public void Init()
    {
        if(itemManager == null)
            itemManager = new ItemManager();
        if (playerData == null)
            playerData = new PlayerData();
    }

    public void GiveSouls(int amount)
    {
        Managers.Game.player.Inventory.AddSoul(amount);
    }
    public void SetLvl(int value) { lvl = value; }
}