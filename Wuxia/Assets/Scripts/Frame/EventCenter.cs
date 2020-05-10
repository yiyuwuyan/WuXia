using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCenter : BaseManager<EventCenter> {

    //1 字典 委托
    //2 观察者模式
    //
    /// <summary>
    /// key 事件名，value 对应事件集
    /// </summary>
    public Dictionary<string, EventInfo> eventDic = new Dictionary<string, EventInfo>();
    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventAction<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventAction<T>(action) as EventInfo);
        }
    }

    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger<T>(string name,T info)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventAction<T>).actions!=null)
              (eventDic[name] as EventAction<T>).actions(info);
        }
    }
    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventAction<T>).actions -= action;
        }
    }

    /// <summary>
    /// 添加监听 无参数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventAction).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventAction(action) as EventInfo);
        }
    }

    /// <summary>
    /// 事件触发 无参数
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventAction).actions != null)
                (eventDic[name] as EventAction).actions();
        }
    }
    /// <summary>
    /// 移除监听 无参数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventAction).actions -= action;
        }
    }
    /// <summary>
    /// 清空事件
    /// 场景更换时
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }

    //避免装箱拆箱
    public interface EventInfo { }
    //避免装箱拆箱
    public class EventAction<T>:EventInfo
    {
        public UnityAction<T> actions;
        public EventAction(UnityAction<T> action)
        {
            actions += action;
        }
    }
    //无参类
    public class EventAction : EventInfo
    {
        public UnityAction actions;
        public EventAction(UnityAction action)
        {
            actions += action;
        }
    }
}
