using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameDataMgr : BaseManager<GameDataMgr> {
    private Dictionary<int, Item> itemInfos = new Dictionary<int, Item>();
    static string PlayerInfo_url = Application.persistentDataPath + "/PlayerInfo.txt";
    private Player playerInfo;

    public void Init()
    {
        Debug.Log("GameDataMgr.init");
        Debug.Log("PlayerInfo_url:" + PlayerInfo_url);

        string info = ResMgr.GetInstance().Load<TextAsset>("Files/ItemInfo").text;
        Debug.Log(info);
        Items items = JsonUtility.FromJson<Items>(info);
        Debug.Log(items.info.Count);
        for (int i = 0; i < items.info.Count; i++)
        {
            itemInfos.Add(items.info[i].id, items.info[i]);
        }

        //初始化角色
        if (File.Exists(PlayerInfo_url))
        {
            //读取记录
            byte[] bytes = File.ReadAllBytes(PlayerInfo_url);
            string json = Encoding.UTF8.GetString(bytes);
            playerInfo = JsonUtility.FromJson<Player>(json);
            Debug.Log(" 读取记录"+playerInfo.name);
        }
        else
        {
            //新建记录并保存
            playerInfo = new Player();
            SavePlayerInfo();
        }
    }
    //保存玩家信息
    public void SavePlayerInfo()
    {
        string json = JsonUtility.ToJson(playerInfo);
        File.WriteAllBytes(PlayerInfo_url, Encoding.UTF8.GetBytes(json));
    }
    public Player GetPlayerInfo()
    {
        return playerInfo;
    }
    public Item GetItemInfo(int id)
    {
        if (itemInfos.ContainsKey(id))
        {
            return itemInfos[id];
        }
        return null;
    }
}
public class Player
{
    public string name;
    public int level;
    public int money;
    public int gem;
    public int pro;
    public List<ItemInfo> items;
    public List<ItemInfo> equips;
    public List<ItemInfo> gems;
    public Player()
    {
        name = "张三";
        level = 1;
        money = 100;
        items = new List<ItemInfo>() {  new ItemInfo(3,10)};
        equips = new List<ItemInfo>() {  new ItemInfo(1,1)};
        gems = new List<ItemInfo>() {  new ItemInfo(5,1)};


    }
}
[System.Serializable]
public class ItemInfo
{
    public int id;
    public int nums;
    public ItemInfo(int id, int nums)
    {
        this.id = id;
        this.nums = nums;
    }
}
public class Items
{
    public List<Item> info;
}

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public string icon;
    public int prices;
    public int type;
    public string tips;
}