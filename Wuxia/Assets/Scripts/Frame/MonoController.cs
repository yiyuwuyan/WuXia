using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour {
    //1 生命周期函数
    //2 事件
    //3 协程

    event UnityAction updateEvent;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (updateEvent !=null)
        {
            updateEvent();
        }
	}
    /// <summary>
    /// 外部 增加 update 事件函数
    /// </summary>
    /// <param name="func"></param>
    public void AddUpdateListener(UnityAction func)
    {
        updateEvent += func;
    }
    /// <summary>
    /// 外部 用于移除update 事件函数
    /// </summary>
    /// <param name="func"></param>
    public void RemoveUpdateListener(UnityAction func)
    {
        updateEvent -= func;
    }
}
