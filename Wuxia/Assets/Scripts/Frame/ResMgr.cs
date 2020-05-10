using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManager<ResMgr> {
    //1 异步加载
    //2 委托和 lamb 表达式
    //3 协程
    //4 泛型
    // Use this for initialization
    void Start () {
		
	}
	
    // 同步加载
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);
        //如果对象是一个GameObject 实例化后再返回
        if (res is GameObject)
        {
            return GameObject.Instantiate(res);
        }
        else
        {
            return res;
        }
    }
    // 异步加载
    public void LoadAsync<T>(string name,UnityAction<T> callback) where T: Object
    {
        MonoMgr.GetInstance(). StartCoroutine(ReallyLoadAsync(name,callback));

    }
    //异步加载协程
    IEnumerator ReallyLoadAsync<T>(string name,UnityAction<T> callback) where T : Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);
        yield return r;
        if (r.asset is GameObject)
        {
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            callback(r.asset as T);
        }
    }
}
