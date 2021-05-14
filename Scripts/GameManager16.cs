using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager16 : MonoBehaviour {

    public GameObject com1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsGetItem()
    {
        int var = GlobalManager.Itemflag & 0x14;

        if (var != 0x14)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
