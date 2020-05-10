using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBase : MonoBehaviour {
    /// <summary>
    /// 控件字典，按控件所在物体名存储对应控件 ，里式转换原则，所有UI组件都继承自 UIBehaviour
    /// </summary>
    Dictionary<string,List< UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
	// Use this for initialization
	void Awake () {
        FindControlInChildern<Button>();
        FindControlInChildern<Image>();
        FindControlInChildern<Slider>();
        FindControlInChildern<Text>();
        FindControlInChildern<InputField>();
        FindControlInChildern<Toggle>();
        FindControlInChildern<ScrollRect>();


    }

    //显示自己
    public virtual void ShowSelf()
    {

    }
    //隐藏自己
    public virtual void HideSelf()
    {
        Destroy(transform.gameObject);
    }
    /// <summary>
    /// 根据键值获取对应的 控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T GetControl<T>( string key) where T:UIBehaviour
    {
        if (controlDic.ContainsKey(key))
        {
            foreach (var item in controlDic[key])
            {
                if (item is T)
                {
                    return item as T;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 获取子物体上的控件，存储到 控件字典
    /// </summary>
    void FindControlInChildern<T>( ) where T:UIBehaviour
    {
        T[] controls = transform.GetComponentsInChildren<T>();
        foreach (var item in controls)
        {
            if (controlDic.ContainsKey(item.gameObject.name))
            {
                controlDic[item.gameObject.name].Add(item);
            }
            else
            {
                controlDic.Add(item.gameObject.name, new List<UIBehaviour> { item});
            }
        }
    }
}
