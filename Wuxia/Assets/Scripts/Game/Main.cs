using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameDataMgr.GetInstance().Init();
        //Debug.Log("item 1: "+GameDataMgr.GetInstance().GetItemInfo(1).name);
        //MusicMgr.GetInstance().PlayBGMusic("back01");//当前音乐格式不对
        UIManager.GetInstance().ShowPanel<MainPanel>("MainPanel",E_UI_Layer.Mid);


    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    MusicMgr.GetInstance().PlaySound("01",false);
        //}
	}



}
