using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : BaseManager<InputMgr> {
    bool isStart = true;
    public InputMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }
    /// <summary>
    /// 每帧检测输入
    /// </summary>
    void MyUpdate()
    {
        if (isStart)
        {
            CheckKey(KeyCode.W);
            CheckKey(KeyCode.A);
            CheckKey(KeyCode.S);
            CheckKey(KeyCode.D);
        }

    }
    void CheckKey(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            EventCenter.GetInstance().EventTrigger("按下", keyCode);
        }
        if (Input.GetKeyUp(keyCode))
        {
            EventCenter.GetInstance().EventTrigger("弹起", keyCode);
        }
    }
    /// <summary>
    /// true 打开输入
    /// </summary>
    /// <param name="v"></param>
    public void StartOrEndCheck(bool v)
    {
        isStart = v;
    }
}
