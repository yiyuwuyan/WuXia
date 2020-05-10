using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsPanel : UIBase {

    public void Init(Item item)
    {
        GetControl<Text>("tipText").text = item.tips;

    }

}
