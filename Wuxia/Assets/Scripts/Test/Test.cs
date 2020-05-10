using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventCenter.GetInstance().AddEventListener<KeyCode>("按下", MyKeyDown);
        EventCenter.GetInstance().AddEventListener<KeyCode>("弹起", MyKeyUp);
        InputMgr.GetInstance().StartOrEndCheck(true);
	}
	void MyKeyDown(KeyCode keyCode)
    {
        Debug.Log("按下" + keyCode);
        switch (keyCode)
        {
   
            case KeyCode.A:

                break;
 
            case KeyCode.D:
                break;

            case KeyCode.S:
                break;

            case KeyCode.W:
                break;
            

            default:
                break;
        }
    }
    void MyKeyUp(KeyCode keyCode)
    {
        Debug.Log("弹起" + keyCode);
        switch (keyCode)
        {

            case KeyCode.A:
                break;

            case KeyCode.D:
                break;

            case KeyCode.S:
                break;

            case KeyCode.W:
                break;


            default:
                break;
        }
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            PoolMgr.GetInstance().GetObj("Prafebs/Test/Cube",null);
        }
	}
}
