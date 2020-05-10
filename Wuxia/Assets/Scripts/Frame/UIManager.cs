using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_UI_Layer
{
    Bot,Mid,Top,System
}
public class UIManager : BaseManager<UIManager> {
    //
    //1 管理所有面板
    //2 提供面板 显示隐藏 接口

    public Dictionary<string, UIBase> panelDic = new Dictionary<string, UIBase>();
    Transform bot;//画布
    Transform mid;//画布
    Transform top;//画布
    Transform system;//画布
    public UIManager()
    {
        GameObject obj= ResMgr.GetInstance().Load<GameObject>("UI/Canvas").gameObject;
        bot = obj.transform.Find("bot");
        mid = obj.transform.Find("mid");
        top = obj.transform.Find("top");
        system = obj.transform.Find("system");
        GameObject.DontDestroyOnLoad(obj);


        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem").gameObject;
        GameObject.DontDestroyOnLoad(obj);

    }
	
    public void ShowPanel<T>(string panelName,E_UI_Layer layer,UnityAction<T> callback =null) where T:UIBase
    {
        if (panelDic.ContainsKey(panelName))
        {
            if (callback!=null)
            {
                callback(panelDic[panelName] as T);
                return;
            }
        }
        ResMgr.GetInstance().LoadAsync<GameObject>("UI/"+panelName,(obj)=> {
            switch (layer)
            {
                case E_UI_Layer.Bot:
                    obj.transform.SetParent(bot);
                    break;
                case E_UI_Layer.Mid:
                    obj.transform.SetParent(mid);
                    break;
                case E_UI_Layer.Top:
                    obj.transform.SetParent(top);
                    break;
                case E_UI_Layer.System:
                    obj.transform.SetParent(system);
                    break;
                default:
                    obj.transform.SetParent(mid);
                    break;
            }

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            T panel = obj.GetComponent<T>();
            panelDic.Add(panelName, panel);
            Debug.Log("panelName:" + panel.name + "  panelDic.count:" + panelDic.Count);
            if (callback !=null)
            {
                
                callback(panel);
            }
            
        });
    }
    public void HidePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }

}
