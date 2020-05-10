using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolMgr : BaseManager<PoolMgr> {

    //public Dictionary<string, List<Transform>> pool = new Dictionary<string, List<Transform>>();
    public Dictionary<string, PoolData> pool = new Dictionary<string, PoolData>();
    Transform poolParent;
    /// <summary>
    /// 获取 池中的 obj （transform）
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public void GetObj(string key,UnityAction<GameObject> callback)
    {


        if (pool.ContainsKey(key) && pool[key].pool.Count>0)
        {
            if (callback!=null)
            {
                callback(pool[key].GetObj().gameObject);
            }
            else
            {
                pool[key].GetObj();
            }

        }
        else
        {
            //obj = GameObject.Instantiate(Resources.Load(key)) as GameObject;
            //obj.gameObject.name = key;
            ResMgr.GetInstance().LoadAsync<GameObject>(key, (o) => {
                o.name = key;
                if (callback!=null)
                {
                    callback(o);
                }

            });
        }
    }

    /// <summary>
    /// 保存 obj （transform）
    /// </summary>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    public void SaveObj(string key,Transform obj)
    {
        obj.gameObject.SetActive(false);
        if (poolParent == null)
        {
            poolParent = new GameObject().transform;
            poolParent.gameObject.name = "pool";
        }
        obj.SetParent(poolParent);

        if (pool.ContainsKey(key))
        {
            pool[key].SaveObj(obj);
        }
        else
        {
            pool.Add(key,new PoolData(obj.gameObject, poolParent));
        }
    }
    /// <summary>
    /// 清空
    /// </summary>
    public void ClearPool()
    {
        pool.Clear();
        poolParent = null;
    }
}
public class PoolData
{
    Transform parent;
    public List<Transform> pool = new List<Transform>();
    public PoolData(GameObject obj,Transform poolObj)
    {
        parent = new GameObject(obj.name).transform;
        parent.SetParent(poolObj);
        pool = new List<Transform>() { obj.transform };
        //SaveObj 有可能需要 待完善
        SaveObj(obj.transform);
    }

    public Transform GetObj()
    {
        Transform tra = pool[0].transform;

        pool.RemoveAt(0);
        tra.gameObject.SetActive(true);
        tra.SetParent(null);
        return tra;
    }
    public void SaveObj(Transform obj)
    {
        obj.gameObject.SetActive(false);
        pool.Add(obj);
        obj.SetParent(parent);
    }
}