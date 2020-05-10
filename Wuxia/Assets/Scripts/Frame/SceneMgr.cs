using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr> {

    //
    //
    //
    /// <summary>
    /// 同步加载
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void LoadScene(string name,UnityAction action)
    {
        SceneManager.LoadScene(name);
        action();
    }
    /// <summary>
    /// 异步加载
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void LoadSceneAsync(string name,UnityAction action)
    {

        MonoMgr.GetInstance().StartCoroutine(LoadSceneAsyncFunc(name,action));
    }
    IEnumerator LoadSceneAsyncFunc(string name, UnityAction action)
    {
        //yield return SceneManager.LoadSceneAsync(name);
        //另一种写法
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            EventCenter.GetInstance().EventTrigger("加载进度更新",ao.progress);
            yield return ao.progress;
        }


        action();
    }
}
