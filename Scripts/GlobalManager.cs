using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class GlobalManager : MonoBehaviour {

    // 本番用
   
    static public int Save_Itemflag = 0x00;
    static public int Itemflag = 0x00;
    static public int Sceneflag = 0x01;
    static public int Continueflag=0;
    static public int TicketCount = 3;
    static public int Hintflag = 0x00;
   


        /*
    static public int Itemflag = 0xFF; //(1～6が有効)
    static public int Sceneflag = 0xFFFF; //(0～15が有効)
    static public int Continueflag = 0; 
    static public int TicketCount = 3;
    static public int  Hintflag = 0xFFFFFFF;//(1～26が有効）
      */



    static public Dictionary<int, string> Scene_dic;
  

    static public int SceneStatus = 0;
    private AudioSource ad = null;
   


    // Use this for initialization
    void Start()
    {
        ADGUnitySDK.IsEnableTest = false;
        ADGUnitySDK2.IsEnableTest = false;
        ADGUnitySDK.initADG();
        ADGUnitySDK2.initADG();

        //データをリストアする


        GetSaveData();

        //シーンとアイテムの辞書を作る
        Scene_dic = new Dictionary<int, string>();
    



        Scene_dic.Add(0, "1ConversationScene");
        Scene_dic.Add(1, "1BConversationScene");
        Scene_dic.Add(2, "3Game Scene");
        Scene_dic.Add(3, "1GameOverScene");
        Scene_dic.Add(4, "2BConversationScene");
        Scene_dic.Add(5, "4GameScene");
        Scene_dic.Add(6, "2GameoverScene");
        Scene_dic.Add(7, "3BConversationScene");
        Scene_dic.Add(8, "6BGameScene");
        Scene_dic.Add(9, "3GameoverScene");
        Scene_dic.Add(10, "4BConversationScene");
        Scene_dic.Add(11, "10BConversationScene");
        Scene_dic.Add(12, "6GameScene");
        Scene_dic.Add(13, "4GameoverScene");
        Scene_dic.Add(14, "5GameoverScene");
        Scene_dic.Add(15, "PlusScene");

      

        DontDestroyOnLoad(this);



        SceneManager.LoadScene("TitleScene");
        //Start Scene
        // SceneManager.LoadScene("1BConversationScene");
        // SceneManager.LoadScene("3Game Scene");
        // SceneManager.LoadScene("4ConversationScene");
        // SceneManager.LoadScene("1GameOverScene");
        // SceneManager.LoadScene("2BConversationScene");
        // SceneManager.LoadScene("4GameScene");
        // SceneManager.LoadScene("2GameoverScene");
        // SceneManager.LoadScene("3BConversationScene");
        // SceneManager.LoadScene("6BGameScene");
        // SceneManager.LoadScene("3GameoverScene");
        // SceneManager.LoadScene("4BConversationScene");
        // SceneManager.LoadScene( "10ConversationScene");
        // SceneManager.LoadScene("6GameScene");
        // SceneManager.LoadScene("4GameoverScene");
        // SceneManager.LoadScene("5GameoverScene");
        // SceneManager.LoadScene("PlusScene");

        // Next Scene
        // SceneManager.LoadScene("2GameScene");
        // SceneManager.LoadScene("3ConversationScene");
        // SceneManager.LoadScene("2BGameScene");
        // SceneManager.LoadScene("5ConversationScene");
        // SceneManager.LoadScene("4BGameScene");
        // SceneManager.LoadScene("7ConversationScene");
        // SceneManager.LoadScene("7BGameScene");
        // SceneManager.LoadScene("10ConversationScene");
        // SceneManager.LoadScene("3GameoverScene");
        // SceneManager.LoadScene("4BConversationScene");
        // SceneManager.LoadScene("10ConversationScene");
        // SceneManager.LoadScene("9BGameScene");


    }

    // Update is called once per frame
    void Update()
    {


    }


    public static void DelTicket()
    {
        TicketCount = TicketCount - 1;

    }

    public static void AddTicket()
    {
        if (TicketCount < 5)
        {
            TicketCount = TicketCount + 1;
            PlayerPrefs.SetInt("TicketCount", TicketCount);
            PlayerPrefs.Save();
        }

    }

    static public void SaveData()
    {
        int tmp = Save_Itemflag | Itemflag;

        if (Save_Itemflag != tmp)
        {
            Save_Itemflag = tmp;
            
        }
        PlayerPrefs.SetInt("Itemflag", Save_Itemflag);
        
        PlayerPrefs.SetInt("Sceneflag", Sceneflag);
        PlayerPrefs.SetInt("Continueflag", Continueflag);
        PlayerPrefs.SetInt("TicketCount", TicketCount);
        PlayerPrefs.SetInt("Hintflag", Hintflag);
        PlayerPrefs.Save();
    }

    static public void GetSaveData()
    {
        Save_Itemflag = PlayerPrefs.GetInt("Itemflag", 0);
        Sceneflag = PlayerPrefs.GetInt("Sceneflag", 0x01);
        Continueflag = PlayerPrefs.GetInt("Continueflag", 0);
        TicketCount = PlayerPrefs.GetInt("TicketCount", 3);
        Hintflag = PlayerPrefs.GetInt("Hintflag", 0);

    }

    static public void ClearData()
    {
   


        PlayerPrefs.SetInt("Itemflag", 0);
        PlayerPrefs.SetInt("Sceneflag", 0x01);
        PlayerPrefs.SetInt("Continueflag", 0);
        PlayerPrefs.SetInt("Hintflag", 0);
        PlayerPrefs.Save();

        GetSaveData();
    }

    static public void SetItem(int num)
    {
      Itemflag = Itemflag | (0x01 << (num-1));
        if (num == 3 || num == 5)
        {
            int tmp = Save_Itemflag | Itemflag;

            if (Save_Itemflag != tmp)
            {
                Save_Itemflag = tmp;

            }
            PlayerPrefs.SetInt("Itemflag", Save_Itemflag);
            PlayerPrefs.Save();
        }
      
    }

    static public int GetItem()
    {
        return Itemflag;
    }

    static public int GetSceneNum(string name)
    {

        int key = Scene_dic.First(x => x.Value == name).Key;
        return key;
    }


    static public void SetLoadScene(int num)
    {
        int val;
        val = ( 0x01 << num ) & Sceneflag;
        if (val != 0)
        {
            Continueflag = num;
            SaveData();
            SceneManager.LoadScene(Scene_dic[num]);
           

        }
        else
        {

            SceneStatus = num;
            SaveData();
            SceneManager.LoadScene("LoadScene");

        }
    }

    static public void SetScene()
    {

            Sceneflag = Sceneflag | (0x01 << SceneStatus);
            TicketCount = TicketCount - 1;
            Continueflag = SceneStatus;
            SaveData();
            SceneManager.LoadScene(Scene_dic[SceneStatus]);
           
      


    }

  


    static public void SetContinueflag(int num)
    {
        Continueflag = num;
    }

    static public void SetHint(int num)
    {
        Hintflag = Hintflag | (0x01 << (num-1));
    }

    static public bool GetHint(int num)
    {
         int val=0;
         val = Hintflag & (0x01 << (num-1));
         if (val == 0) return false;
         else return true;
            
    }

   

   

    static public void PushButtonShop()
    {
        Save_Itemflag = 0xFF;
        PlayerPrefs.SetInt("Sceneflag", 0xFFFF);
        PlayerPrefs.SetInt("Itemflag", Save_Itemflag);
        PlayerPrefs.SetInt("TicketCount", 0);
        PlayerPrefs.Save();
        GetSaveData();
    }







    static public void PushLoadScene(int num)
    {
       
        Continueflag = num;
        PlayerPrefs.SetInt("Continueflag", Continueflag);
        PlayerPrefs.Save();

        SceneManager.LoadScene(Scene_dic[num]);



    }

    private void OnDestroy()
    {
        ADGUnitySDK.finishADG();
        ADGUnitySDK2.finishADG();
    }

    public void ADGFailedToReceiveAd(string msg)
    {
        if (ADGUnitySDK.canCallADG())
        {
            // バナー広告の場合
            ADGUnitySDK.loadADG();

            // インタースティシャル広告の場合
            // ADGUnitySDK.loadInterADG ();
        }

        if (ADGUnitySDK2.canCallADG())
        {
            // バナー広告の場合
            ADGUnitySDK2.loadADG();

            // インタースティシャル広告の場合
            // ADGUnitySDK.loadInterADG ();
        }
    }

    







}
