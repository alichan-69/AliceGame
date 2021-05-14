using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Timer : MonoBehaviour {
  
    public Transform clock;
    public int count = 6;
    public Flowchart flowChart;
    public GameObject panelAll;
    bool sflag = false;
    float stime;
    float timecount;

    // Use this for initialization
    void Start () {

        timecount = 0;
		
	}
	
    public void SetTimerCount(int tcount)
    {
       
        count = tcount;

    }

    public void TimerStart()
    {
        if (!panelAll.activeSelf)
        {
            stime = Time.time;
            sflag = true;
        }
        
    }

    public void TimerStop()
    {
        sflag = false;
        timecount = timecount + (Time.time - stime);



    }
	// Update is called once per frame
	void Update ()
    {
        if (sflag)
        {
            if (timecount + (Time.time - stime) <= 180)
            {
                transform.RotateAround(clock.position, Vector3.back, count * Time.deltaTime);

            }
            else if (timecount + (Time.time - stime) > 180)
            {
                sflag = false;
                flowChart.ExecuteBlock("TimeUp");
            }
        }
       
    }
}
