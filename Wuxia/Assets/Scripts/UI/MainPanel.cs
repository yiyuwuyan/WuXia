using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UIBase {

    void Start()
    {
        GetControl<Button>("bagBtn").onClick.AddListener(()=> { UIManager.GetInstance().ShowPanel<BagPanel>("BagPanel",E_UI_Layer.Mid); }); ;

    }
    void SetPlayMessage(Player p)
    {
        GetControl<Text>("playerNametxt").text=p.name;
    }
}
