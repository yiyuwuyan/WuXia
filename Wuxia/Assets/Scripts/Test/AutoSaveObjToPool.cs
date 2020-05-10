using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaveObjToPool : MonoBehaviour {

    public float LifeTime=1;
    private void OnEnable()
    {
        Invoke("SaveThis", LifeTime);
    }
    void SaveThis()
    {
        PoolMgr.GetInstance().SaveObj(this.gameObject.name, transform);
    }

}
