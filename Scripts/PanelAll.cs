using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearChildren()
    {
        
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                if ( child.gameObject.activeSelf)
                {
                    transform.gameObject.SetActive(false);
                    child.gameObject.SetActive(false);
                   
                }

            }
            

        }
    }

  

}
