using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SkipButton : MonoBehaviour {

    public  Flowchart flowchart;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PushSkip()
    {
        var list = flowchart.GetExecutingBlocks();
        list[0].Stop();
       
        int index = list[0].GetLabelIndex("SkipLabel"); 

        list[0].JumpToCommandIndex = index;
        
        
    }
}
