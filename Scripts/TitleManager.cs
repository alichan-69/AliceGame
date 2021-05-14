using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class TitleManager : MonoBehaviour {

 

    
    public Image ticket1;
    public Image ticket2;
    public Image ticket3;
    public Image ticket4;
    public Image ticket5;
    public Sprite ticket_true;
    public Sprite ticket_false;
   
   

    public GameObject loadpanel;
    public GameObject stagepanel;
    public GameObject stageselectpanel1;
    public GameObject stageselectpanel2;
    public Button ButtonScene0;
    public Button ButtonScene1;
    public Button ButtonScene2;
    public Button ButtonScene3;
    public Button ButtonScene4;
    public Button ButtonScene5;
    public Button ButtonScene6;
    public Button ButtonScene7;
    public Button ButtonScene8;
    public Button ButtonScene9;
    public Button ButtonScene10;
    public Button ButtonScene11;
    public Button ButtonScene12;
    public Button ButtonScene13;
    public Button ButtonScene14;
    public Button ButtonScene15;
    public GameObject PanelStart;
    public GameObject PanelMovie;
    public GameObject PanelOK;
    public GameObject Panelerr;
    public Text text1;
  
    public Image imageback;
    public Image imagebackx;
    public Image title;
    public Image titlex;
    public Canvas canvas;
  
 



    private Button[] ButtonScenes;
    static private Image[] TicketLabels;



   



    // Use this for initialization
    void Start ()
    {
        //最新データを取得する

        GlobalManager.GetSaveData();

        loadpanel.SetActive(false);
        stagepanel.SetActive(false);

      
        ButtonScenes = new Button[16];
        ButtonScenes[0] = ButtonScene0;
        ButtonScenes[1] = ButtonScene1;
        ButtonScenes[2] = ButtonScene2;
        ButtonScenes[3] = ButtonScene3;
        ButtonScenes[4] = ButtonScene4;
        ButtonScenes[5] = ButtonScene5;
        ButtonScenes[6] = ButtonScene6;
        ButtonScenes[7] = ButtonScene7;
        ButtonScenes[8] = ButtonScene8;
        ButtonScenes[9] = ButtonScene9;
        ButtonScenes[10] = ButtonScene10;
        ButtonScenes[11] = ButtonScene11;
        ButtonScenes[12] = ButtonScene12;
        ButtonScenes[13] = ButtonScene13;
        ButtonScenes[14] = ButtonScene14;
        ButtonScenes[15] = ButtonScene15;

        TicketLabels = new Image[5];
        TicketLabels[0] = ticket1;
        TicketLabels[1] = ticket2;
        TicketLabels[2] = ticket3;
        TicketLabels[3] = ticket4;
        TicketLabels[4] = ticket5;

       

        //ライフを表示する
        for (int i=0; i < GlobalManager.TicketCount; i++)
        {
            TicketLabels[i].sprite = ticket_true;
        }

        var rectT = canvas.GetComponent<RectTransform>();


        // キャンバスサイズを取得
        var width = rectT.sizeDelta.x;
        var height = rectT.sizeDelta.y;

        //iphonXの場合はSayDialogの名前とタイトルを入れ替える位置を変更する
        if (height / width > 1.9)
        {
            imageback.gameObject.SetActive(false);
            imagebackx.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            titlex.gameObject.SetActive(true);


        }


    }

    // Update is called once per frame
    void Update ()
    {

        for (int i = 0; i < GlobalManager.TicketCount; i++)
        {
            TicketLabels[i].sprite = ticket_true;
        }
         for (int i= GlobalManager.TicketCount; i < 5 ; i++)
        {
            TicketLabels[i].sprite = ticket_false;

        }

      



    }

 

    public void PushSelectSceneButton()
    {


        int tmp = GlobalManager.Sceneflag;
        //全てのシーンボタンの選択状態を設定する
        for (int i = 0; i < 16; i++)
        {
            if ((tmp & 0x01) == 1)
            {
                ButtonScenes[i].interactable = true;
            }
            else
            {
                ButtonScenes[i].interactable = false;
            }
            tmp = tmp >> 1;

        }

        stagepanel.SetActive(true);
        stageselectpanel1.SetActive(true);
        stageselectpanel2.SetActive(false);




      
        
    }

    public void PushNextScenes()
    {
        stageselectpanel1.SetActive(false);
        stageselectpanel2.SetActive(true);

    }

    public void PushReturnScenes()
    {
        stageselectpanel2.SetActive(false);
        stageselectpanel1.SetActive(true);

    }

  

    public void PushLoadScene(int num)
    {
        GlobalManager.PushLoadScene(num);
     


    }

    public void PushContinueButton()
    {


        string val = GlobalManager.Scene_dic[GlobalManager.Continueflag];
        SceneManager.LoadScene(val);



    }

    public void PushStartButton(){

        stagepanel.SetActive(true);
        PanelStart.SetActive(true);

    }

   

    public void PushMovieButton()
    {
        stagepanel.SetActive(true);
        if (GlobalManager.TicketCount < 5)
        {
            text1.text = "チケットが回復しました。";
            PanelMovie.SetActive(true);
        }
        else
        {
            text1.text = "チケットは上限まで回復しています。";
            PanelOK.SetActive(true);
            
         
        }
      
       
      
    }

    public void StartMovie()
    {
       

        PanelMovie.SetActive(false);
        SDKTest.SetTitleMovieObj(this);

        

        if (SDKTest.m_status == 1)
        {
         
            if ( VAMPUnitySDK.show() == false )
            {
          
                SDKTest.m_status = 0;
            }
            else
            {
                AudioSource ad = GetComponent<AudioSource>();
                ad.mute = true;
            }
         }

        if (SDKTest.m_status == 0)
        {

              VAMPUnitySDK.load();

               PanelOK.SetActive(false);
               Panelerr.SetActive(true);

        }

         
    }

 
    public void MovieEnd(bool flag)
    {
        AudioSource ad = GetComponent<AudioSource>();
        ad.mute = false;

        if (flag == true)
        {
            PanelOK.SetActive(true);
            Panelerr.SetActive(false);
            GlobalManager.AddTicket();
        }
        else
        {
            PanelOK.SetActive(false);
            Panelerr.SetActive(true);
        }
    }

    public void TicketOK()
    {
        stagepanel.SetActive(false);
        PanelOK.SetActive(false);
        Panelerr.SetActive(false);
    }

    public void ClearButton()
    {
        stagepanel.SetActive(false);
        stageselectpanel1.SetActive(false);
        stageselectpanel2.SetActive(false);
        PanelStart.SetActive(false);
        PanelOK.SetActive(false);
        PanelMovie.SetActive(false);
        Panelerr.SetActive(false);

    }

    public void StartMessage()
    {
      

    }

    public void StartOK()
    {

        GlobalManager.ClearData();

        SceneManager.LoadScene("1ConversationScene");
       
    }

    public void PushButtonShop()
    {
        GlobalManager.PushButtonShop();
     
    
    }
    


    void OnApplicationPause(bool pauseStatus)
    {

        //バックグラウンド復帰時には音をならす
        if (!pauseStatus)
        {
            AudioSource ad = GetComponent<AudioSource>();
            ad.mute = false;
        }
        
    }


}
