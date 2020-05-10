using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingScript : MonoBehaviour {
    private float timer; //时间计时

    // Use this for initialization
    void Start () {
        timer = 60;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        //Debug.Log("Time.time :"+Time.time+" timer :"+timer);
        if (timer <= 0)
        {
            Debug.Log(string.Format("Timer1 is up !!! time=${0}", Time.time));
            timer = 60.0f;
            DoWork();
        }
    }
    //修炼
    void DoWork()
    {

    }
}
public class PlayerData
{
    public string username = "";
    public uint userID = 0;


}

