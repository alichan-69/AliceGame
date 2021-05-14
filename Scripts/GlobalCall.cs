using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLoadScene(int num)
    {
        GlobalManager.SetLoadScene(num);

    }

    public void SetItem(int num)
    {
        GlobalManager.SetItem(num);


    }
}
