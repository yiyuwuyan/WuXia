using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : UIBase {
    Transform content;
    void Start()
    {
        GetControl<Button>("closeBtn").onClick.AddListener(()=> { HideSelf(); });
        content = GetControl<ScrollRect>("BagScroll").content;
        Init();
    }
    void Init()
    {
        Player p = GameDataMgr.GetInstance().GetPlayerInfo();
        for (int i = 0; i < p.items.Count; i++)
        {
            ItemCell temp = ResMgr.GetInstance().Load<GameObject>("UI/ItemCell").GetComponent<ItemCell>();

            temp.transform.SetParent(content);

            temp.transform.localScale = Vector3.one;
            temp.Init(p.items[i]);
        }
        for (int i = 0; i < p.equips.Count; i++)
        {
            ItemCell temp = ResMgr.GetInstance().Load<GameObject>("UI/ItemCell").GetComponent<ItemCell>();
            temp.transform.SetParent(content);
            temp.transform.localScale = Vector3.one;
            temp.Init(p.equips[i]);
        }
        for (int i = 0; i < p.gems.Count; i++)
        {
            ItemCell temp = ResMgr.GetInstance().Load<GameObject>("UI/ItemCell").GetComponent<ItemCell>();
            temp.transform.SetParent(content);
            temp.transform.localScale = Vector3.one;
            temp.Init(p.gems[i]);
        }
    }
}
