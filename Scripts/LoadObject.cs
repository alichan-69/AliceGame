using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadObject : MonoBehaviour {

    public GameObject next1;
    public GameObject movie2;
    public GameObject panelok;
    public GameObject panelerr;
  
   

	// Use this for initialization
	void Start () {

     


    }
	
	// Update is called once per frame
	void Update () {
		
	}

   

    

    public void MovieEnd(bool flag)
    {
        if (flag == true)
        {
            GlobalManager.AddTicket();
            panelok.SetActive(true);
            panelerr.SetActive(false);
        }
        else
        {
            //動画を最後まで見ていないで終了した場合
            panelerr.SetActive(true);
            panelok.SetActive(false);

        }
        ShowPanel();
    }

    public void ShowPanel()
    {
        panelok.SetActive(false);
        panelerr.SetActive(false);
        if (GlobalManager.TicketCount > 0)
        {
            next1.SetActive(true);
            movie2.SetActive(false);
           
        }
        else
        {
            next1.SetActive(false);
            movie2.SetActive(true);
         

        }
    }

    public void PushMovie()
    {
        //動画を再生する
        SDKTest.SetLoadMovieObj(this);


        if (SDKTest.m_status == 1)
        {
            if (VAMPUnitySDK.show() == false)
            {
                SDKTest.m_status = 0;
            }
        }

        if (SDKTest.m_status == 0)
        {

            VAMPUnitySDK.load();

            panelerr.SetActive(true);
            panelok.SetActive(false);
        }

    }




    public void SetScene()
    {
       
        movie2.SetActive(false);
        next1.SetActive(false);
        panelok.SetActive(false);

        GlobalManager.SetScene();

    }

    public void ShowTitleScene()
    {
      
        SceneManager.LoadScene("TitleScene");


    }



}
