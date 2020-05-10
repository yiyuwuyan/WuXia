using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemCell : UIBase {

    Item item=new Item();
    public void Init(ItemInfo i)
    {
        //Debug.Log("the id:"+i.id);
        //Debug.Log("the icon:"+ GameDataMgr.GetInstance().GetItemInfo(i.id).icon);
        GetControl<Image>("item").sprite = ResMgr.GetInstance().Load<Sprite>("icon/"+GameDataMgr.GetInstance().GetItemInfo(i.id).icon);
        GetControl<Text>("itemNum").text = "数量：" + i.nums;
        item = GameDataMgr.GetInstance().GetItemInfo(i.id);

        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        #region PointerEnter
            //UnityAction<BaseEventData> enter = new UnityAction<BaseEventData>(PointerEnter);
            //EventTrigger.Entry myenter = new EventTrigger.Entry();
            //myenter.eventID = EventTriggerType.PointerEnter;
            //myenter.callback.AddListener(enter);
            //trigger.triggers.Add(myenter);
        #endregion
        #region PointerExit

            EventTrigger.Entry myexit = new EventTrigger.Entry();
            myexit.eventID = EventTriggerType.PointerExit;
            myexit.callback.AddListener(PointerExit);
            trigger.triggers.Add(myexit);
        #endregion
        #region NewPointEnter
        EventTrigger.Entry newEnter = new EventTrigger.Entry();
        newEnter.eventID = EventTriggerType.PointerEnter;
        newEnter.callback.AddListener(PointerEnter);
        trigger.triggers.Add(newEnter);
        #endregion
    }
    void PointerEnter( BaseEventData data)
    {
        UIManager.GetInstance().ShowPanel<TipsPanel>("TipsPanel", E_UI_Layer.Mid,(panel)=>{

            Debug.Log("   item:"+item.name);
            Debug.Log("panel: " + panel.name);
            panel.transform.position = transform.position;
            panel.Init(item);
        });
    }
    void PointerExit(BaseEventData data)
    {
        UIManager.GetInstance().HidePanel("TipsPanel");
    }
}
