using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Fungus;


public class GameMenu : MonoBehaviour {


    private const int Hinto1 = 1;
    private const int Hinto2 = 2;
    private const int Hinto3 = 3;
    private const int HintoK = 4;

    public GameObject Backpanel;
    public GameObject Menupanel;
    public GameObject Itemspanel;
    public GameObject Hintpanel;
    public GameObject Moviepanel;
    public GameObject Moviecontrol;
    public GameObject Messagepanel;
    public GameObject Itempanel;
    public GameObject Titlepanel;
    public VideoPlayer mPlayer;
    public Text message;
    public Sprite clear_hint;
    public Sprite hint1;
    public Sprite hint2;
    public Sprite hint3;
    public int select_item = 0;
    public Flowchart item_flowchart;
    public Flowchart flowchart;
    public Sprite Item1;
    public Sprite Item2;
    public Sprite Item3;
    public Sprite Item4;
    public Sprite Item5;
    public Sprite Item6;
    public Sprite Item7;
    public Sprite Item8;
    public Sprite Item9;
    public Sprite Item10;
    public Sprite Item11;
    public Sprite Item12;
    public Button B_Item1;
    public Button B_Item2;
    public Button B_Item3;
    public Button B_Item4;
    public Button B_Item5;
    public Button B_Item6;
    public Text Text;
    public Button HintButton;
    public Button Hint3Button;

 
    private Button[] ButtonItems;
    private int hintNo=0;  

    private int Button;

    public GameObject canvas;
    public GameObject name1;
    public GameObject name2;
    public GameObject story1;
    public GameObject story2;
  






    // Use this for initialization
    void Start() {

        string scene_name;
        int tmp;

        HideMenu();
        Button = Hinto1;

      


        ButtonItems = new Button[6];
        ButtonItems[0] = B_Item1;
        ButtonItems[1] = B_Item2;
        ButtonItems[2] = B_Item3;
        ButtonItems[3] = B_Item4;
        ButtonItems[4] = B_Item5;
        ButtonItems[5] = B_Item6;
        scene_name = SceneManager.GetActiveScene().name;

      

        if (scene_name  == "2GameScene" || scene_name == "3Game Scene" || scene_name == "4GameScene" || scene_name == "6BGameScene" || scene_name == "9BGameScene" 
            || scene_name == "5GameScene" || scene_name == "10ConversationScene" || scene_name == "6GameScene")
        {
            HintButton.interactable = true;
            Hint3Button.interactable = false;

        }

        if((scene_name == "2GameScene" && GlobalManager.GetHint(2)) || (scene_name == "3Game Scene" && GlobalManager.GetHint(5))
            || (scene_name == "4GameScene" && GlobalManager.GetHint(8)) || (scene_name == "5GameScene" && GlobalManager.GetHint(15))
            || (scene_name == "6BGameScene" && GlobalManager.GetHint(11)) || (scene_name == "9BGameScene" && GlobalManager.GetHint(18))
            || (scene_name == "10ConversationScene" && GlobalManager.GetHint(22)) || (scene_name == "6GameScene" && GlobalManager.GetHint(25)))
        {
            Hint3Button.interactable = true;
        }

        //シーン毎のItemフラグの設定
        if (scene_name == "1ConversationScene" || scene_name == "1BConversationScene" || scene_name == "3Game Scene" || scene_name == "1GameOverScene")
        {
            GlobalManager.Itemflag = 0x00;
        }
        else if (scene_name == "2BConversationScene" || scene_name == "4GameScene" || scene_name == "2GameoverScene")//Item1
        {

            GlobalManager.Itemflag = 0x01;

        }
        else if (scene_name == "3BConversationScene")//Item2,Item3
        {
            tmp = GlobalManager.Save_Itemflag & 0x07;
            if (tmp != 0x07)
            {
                GlobalManager.Itemflag = 0x03;
            }
            else
            {
                GlobalManager.Itemflag = 0x07;
            }

        }
        else if (scene_name == "6BGameScene" || scene_name == "3GameoverScene")//Item6
        {

            tmp = GlobalManager.Save_Itemflag & 0x04;
            if (tmp != 0x04)
            {
                GlobalManager.Itemflag = 0x23;
            }
            else
            {
                GlobalManager.Itemflag = 0x27;
            }

        }
        else if (scene_name == "4BConversationScene" || scene_name == "10BConversationScene")//Item4,Item5
        {

            tmp = GlobalManager.Save_Itemflag & 0x04;
            if (tmp != 0x04)
            {
                tmp = GlobalManager.Save_Itemflag & 0x10;
                if (tmp != 0x10)
                {
                    GlobalManager.Itemflag = 0x2B;
                }
                else
                {
                    GlobalManager.Itemflag = 0x3B;
                }
            }
            else
            {
                tmp = GlobalManager.Save_Itemflag & 0x10;
                if (tmp != 0x10)
                {
                    GlobalManager.Itemflag = 0x2F;
                }
                else
                {
                    GlobalManager.Itemflag = 0x3F;
                }
            }
        }

        else if (scene_name == "6GameScene" || scene_name == "4GameoverScene" || scene_name == "5GameoverScene" || scene_name == "PlusScene")//allclear
        {
            GlobalManager.Itemflag = 0x3F;
        }


        var rectT = canvas.GetComponent<RectTransform>();
        

        // キャンバスサイズを取得
        var width = rectT.sizeDelta.x;
        var height = rectT.sizeDelta.y;

        //iphonXの場合はSayDialogの名前とstoryの位置を変更する
        if (height/width > 1.9)
        {
            rectT = name1.GetComponent<RectTransform>();
            rectT.offsetMin = new Vector2(40, 165);
            rectT.offsetMax = new Vector2(-360, -624);

            rectT = name2.GetComponent<RectTransform>();
            rectT.offsetMin = new Vector2(40, 165);
            rectT.offsetMax = new Vector2(-360, -624);

            rectT = story1.GetComponent<RectTransform>();
            rectT.offsetMin = new Vector2(60, 30);
            rectT.offsetMax = new Vector2(-40, -712);

            rectT = story2.GetComponent<RectTransform>();
            rectT.offsetMin = new Vector2(60, 30);
            rectT.offsetMax = new Vector2(-40, -712);

            story1.GetComponent<Text>().fontSize = 24;
            story2.GetComponent<Text>().fontSize = 24;

            name1.GetComponent<Text>().fontSize = 24;
            name2.GetComponent<Text>().fontSize = 24;


        }
        // 設定
      

    }

    // Update is called once per frame
    void Update() {

       

    }

  
        

    public void ShowMenu()
    {
        if (Menupanel.activeSelf)
        { 
            HideMenu();
        }
        else
        {
            HideMenu();
            Backpanel.SetActive(true);
            Menupanel.SetActive(true);
        }
    }

    public void HideMenu()
    {
        if ( Itempanel.activeSelf)
        {
            Itempanel.SetActive(false);
        }
        else
        {
            Backpanel.SetActive(false);
            Menupanel.SetActive(false);
            Itemspanel.SetActive(false);
            Hintpanel.SetActive(false);
            Moviepanel.SetActive(false);
            Messagepanel.SetActive(false);
        }
    }
      
       

    public void ReturnMenu()
    {
        Titlepanel.SetActive(false);
        Itemspanel.SetActive(false);
        Hintpanel.SetActive(false);
        Menupanel.SetActive(true);

    }

    public void ReturnItemsPanel()
    {
        Itempanel.SetActive(false);
        Itemspanel.SetActive(true);
    }

    public void ReturnHintPanel()
    {
        Messagepanel.SetActive(false);
        Moviepanel.SetActive(false);
        Hintpanel.SetActive(true);

    }

    public void ShowTitleScene()
    {
        item_flowchart.ExecuteBlock("End");
        SceneManager.LoadScene("TitleScene");
        

    }


    public void ShowTitlePanel()
    {
        Menupanel.SetActive(false);
        Titlepanel.SetActive(true);
    }


    public void ShowItemsPanel()
    {
        int tmp;
        tmp = GlobalManager.Itemflag;

        for (int i = 0; i < 6; i++)
        {
            if ((tmp & 0x01) == 1)
            {
                ButtonItems[i].gameObject.SetActive(true);
            }
            else
            {
                ButtonItems[i].gameObject.SetActive(false);
            }
            tmp = tmp >> 1;

        }

        Menupanel.SetActive(false);
        Itemspanel.SetActive(true);
        Itempanel.SetActive(false);

    }

    public void ShowItem( int item_num)
    {
        Itempanel.SetActive(true);
        item_flowchart.SetIntegerVariable("item_num", item_num);
       

        switch (item_num)
        {
            case 1:
                Itempanel.GetComponent<Image>().sprite = Item1;

                break;
            case 2:
                Itempanel.GetComponent<Image>().sprite = Item2;

                break;
            case 3:
                Itempanel.GetComponent<Image>().sprite = Item3;

                break;
            case 4:
                Itempanel.GetComponent<Image>().sprite = Item4;

                break;
            case 5:
                Itempanel.GetComponent<Image>().sprite = Item5;

                break;
            case 6:
                Itempanel.GetComponent<Image>().sprite = Item6;

                break;
            case 7:
                Itempanel.GetComponent<Image>().sprite = Item7;

                break;
            case 8:
                Itempanel.GetComponent<Image>().sprite = Item8;
                break;
            case 9:
                Itempanel.GetComponent<Image>().sprite = Item11;
                break;
            case 10:
                Itempanel.GetComponent<Image>().sprite = Item10;

                break;
            case 11:
                Itempanel.GetComponent<Image>().sprite = Item11;

                break;
            case 12:
                Itempanel.GetComponent<Image>().sprite = Item12;

                break;
        }
        
         

        
    }

    public void ShowHint()
    {
        Menupanel.SetActive(false);
        Hintpanel.SetActive(true);

    }

    public void ShowMessage(int text_num)
    {
        Hintpanel.SetActive(false);
        Moviepanel.SetActive(false);
        Messagepanel.SetActive(true);


        switch (text_num)
        {
            case 1:
                DisplayMessage("まずは鎖でつながれたクマのぬいぐるみを解放してあげよう。\nそのためにはポットに引っかかっているペンチが必要だ。\n高い場所に手が届く物があればいいのだが･･･。");
                break;
            case 2:
                if (GlobalManager.GetHint(2))
                {
                    DisplayMessage("クマのぬいぐるみをとったら、ぬいぐるみを調べてみよう。\nお腹に何か詰まっている。\nお腹の中を見るためには、お腹を開く物が必要だ。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 2;

                }
                break;
            case 3:
                if (GlobalManager.GetHint(3))
                {
                    DisplayMessage("①紫色のマカロンの下にある杖をとる。\n" +
                    "②杖を使い、ポットの先に引っかかっているペンチをとる。\n" +
                    "③ペンチを使い、クマのぬいぐるみをつないでいる鎖をはずし、クマのぬいぐるみをとる。\n" +
                    "④星のモチーフが飾られた壁の下にあるハサミをとる。\n" +
                    "⑤ハサミを使い、クマのお腹を開き、鍵をとる。\n" +
                    "⑥鍵を使い、メモのはってある扉を開く。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 3;

                }

                break;
            case 4:
                DisplayMessage("まずはカードの謎を解いて、どのカップに毒のお茶が入っているかを見極めよう。\n" +
                    "カードに書いてある文字は、ある法則に従って変化しているようだ。\n" +
                    "例えば、”あり”が”うん”に変化する時、どう変化しているか？\n" +
                    "50音表で文字のずれを数えてみると、”あ”から”う”に変化する時は、後ろに2文字、”り”から”ん”に変化する時は後ろに6文字ずれている。\n" +
                    "他の単語はどうだろうか?");
                break;
            case 5:
                if (GlobalManager.GetHint(5))
                {
                    DisplayMessage("毒のお茶がどれか分かったら、次はそれを避けなければいけない。\n" +
                    "しかし、このまま相手が毒のお茶を飲まないままゲームが続けば、最後にはこちらにお茶が残ってしまう。\n" +
                    "どうにかできないか。\n" +
                    "おや？一気にいくつものお茶を選択できるようだ。\n" +
                    "これでなんとかなるかもしれない。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 5;

                }
                break;
            case 6:
                if (GlobalManager.GetHint(6))
                {
                    DisplayMessage("①毒のお茶が入ったカップは赤いカップなので、赤いカップ以外のカップを自分のターンに全て選択し、飲むボタンを押す。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 6;

                }
                break;
            case 7: DisplayMessage("”この部屋で一番軽い物”とはなんだろうか？\n" +
                 "まずはそれを考えてみよう。\n" +
                 "単に部屋の中で見つかった物の中で一番軽い物ではないのかもしれない。");
                break;
            case 8:
                if (GlobalManager.GetHint(8))
                {
                    DisplayMessage("傘をフックにひっかけてフックのついたドアを開き、斧を使って鎖を壊し、ドアを開くと靴下が見つかる。\n" +
                    "靴下の中に入っているお菓子を食べると、靴下が空っぽになる。\n" +
                    "小さなドアに書いてある謎では、日本語をローマ字に直して各ローマ字に対応する数字を考えてみよう。\n" +
                    "謎の答えを入力すると、送風口のスイッチがつく。\n" +
             "これで、”この部屋で一番軽い物”を作る準備は整った。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 8;

                }
                break;
            case 9:
                if (GlobalManager.GetHint(9))
                {
                    DisplayMessage("①ミアのそばにある傘をとる。\n" +
                 "②傘をフックに引っかけて、フックのついたドアを開け、斧をとる。\n" +
                 "③斧を使い、鎖のついたドアの鎖を壊し、靴下をとる。\n" +
                 "④靴下の中のお菓子を食べる。\n" +
                 "⑤小さなドアのついたドアの中にあるダイアルに3112と入力する。\n" +
                 "⑥靴下を送風口に使い、空気を入れた後に、台の上に置く。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 9;
                }
                break;
            case 10:
                DisplayMessage("部屋を歩き回っているノアが気になる。");
                break;
            case 11:
                if (GlobalManager.GetHint(11))
                {
                    DisplayMessage("ノアを追いかけてみよう。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 11;

                }
                break;
            case 12:
                if (GlobalManager.GetHint(12))
                {
                    DisplayMessage("①ノアに話しかけた後移動ボタンを押すということを、ノアがマカロンのイスに座るまでくり返す。\n" +
                    "②ノアがマカロンのイスに座ったら、ノアにまた話しかけまくろう。");

                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 12;

                }
                break;
            case 13:
                break;
            case 14:
                DisplayMessage(
                "ピンク色のマカロンを開くと、宝箱が入っている。\n" +
                "宝箱を開くには、ダイアルを正しい数字に合わせなければいけない。\n" +
                "ダイアルの上には、マシュマロと4つのマークが描かれている。\n" +
                "部屋の中から、ダイアルに描かれている絵に似た場所を探してみよう。\n");

                break;
            case 15:
                if (GlobalManager.GetHint(15))
                {
                    DisplayMessage("檻の中に入ったケーキを食べると、中からライターがでてくる。\n" +
                    "ライターを使えるところはどこだろうか？\n" +
                    "部屋の物を調べると、ある物が少しとけていることが分かるので、ライターを使って完全にとかしてしまおう。\n" +
                    "中からでてきた物を使って、ある場所をこじ開ければそこにイザナがいる。");

                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 15;

                }
                break;
            case 16:
                if (GlobalManager.GetHint(16))
                {
                    DisplayMessage("①ピンク色のマカロンを開き、宝箱をとる。\n" +
                 "②宝箱のダイアルに4702と入力し、檻の鍵をとる。\n" +
                 "③檻の錠前に鍵をさして、中からケーキをとりだす。\n" +
                 "④ケーキを食べて、中からライターをとりだす。\n" +
                 "⑤ライターの火をつけて、ダイヤのついた砂糖菓子の山をとかし、中からバールをとりだす。\n" +
                 "⑥大きなカップケーキをずらし、下にあるふたをバールでこじ開ける。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 16;

                }
                break;
            case 17:
                DisplayMessage("コハルの左にある箱のタグには”物語を全て集めた人へ”と書かれている。\n" +
                    "物語を全て集めるとは、今までの全てのENDを集めること。\n" +
                    "タイトルのステージ選択を利用して、ENDを全てあつめよう。\n" +
                    "ENDを全て集めれば、箱は開く。");

                break;
            case 18:
                if (GlobalManager.GetHint(18))
                {
                    DisplayMessage("箱を開くと、中には油が入っている。\n" +
                    "これで脱出の材料はそろった。\n" +
                    "劇場から脱出するには、コハルと衛兵をぬけて、出口までたどりつかなければならない。\n" +
                    "シャンデリアに火のついたろうそくがたくさんのっているが、これと油を利用して、この場を混乱させることができないだろうか･･･？");

                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 18;
                }
                break;
            case 19:
                if (GlobalManager.GetHint(19))
                {
                    DisplayMessage("①タイトルのステージ選択でENDを集める。(回収方法→BADEND1:STAGE2で赤いお茶を飲む。BADEND2:STAGE4で空気の入った靴下以外の物を台に置く。BADEND3:STAGE6で3分をスキップ。BADEND4:STAGE8で答えを3回ミス。BADEND5:STAGE8でシャンデリア以外の物を撃つ。NORMALEND:STAGE7で受けないを選ぶ。)\n"+
                                  "②コハルの横にある箱をタグをずらして開き、油を観客席にまき、銃でシャンデリアを撃つ。");

                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 19;
                }
                break;
            case 20:
                DisplayMessage("ヒントが解放されました！");
                Hint3Button.interactable = true;
                GlobalManager.SetHint(hintNo);
                break;
            case 21:
                DisplayMessage("STAGE7でゲームを”受ける”という選択しをだすためには、他のステージに落ちている2つのアイテムを拾わなければいけない。\n" +
                    "タイトルのステージ選択を使って、アイテムを探してみよう。");
                break;
            case 22:
                if (GlobalManager.GetHint(22))
                {
                    DisplayMessage("1つ目のアイテムはSTAGE4に落ちており、2つ目のアイテムはSTAGE6に落ちている。\n" +
                    "タイトルのステージ選択を使ってアイテムを探してみよう。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 22;

                }
                break;
            case 23:
                if (GlobalManager.GetHint(23))
                { 
                    DisplayMessage("①STAGE4で次の部屋に行く直前に倒れているミアの右手の先にある銃をとる。\n" +
                    "②STAGE6で次の部屋に行く直前に大きなカップケーキの左下にある手紙をとる。\n" +
                    "③STAGE7でゲームを”受ける”という選択しがでるので、選ぶ。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 23;

                }
                break;
            case 24:
                
                    DisplayMessage("①対戦者達の関係は幼なじみ。\n" +
                    "②対戦者達の関係が幼なじみだったことを示す証拠は集合写真と対戦者の二人組が全員幼なじみどうしだったという事実。\n" +
                    "③対戦者達が幼なじみになった場所を示す情報は花園孤児院のポスター。");
                break;
            case 25:
                if (GlobalManager.GetHint(25))
                {
                    DisplayMessage("④対戦者達が花園孤児院で幼なじみになったことを示す物は集合写真のイザナの右上に写るバラのマーク。\n" +
                "⑤花園孤児院の裏の顔を示す情報はカルテ。\n" +
                "⑥花園孤児院が裏の顔を持っていたことを示している物はカルテの一番下にある項目に書いてある価格。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 25;

                }
                break;
            case 26:
                if (GlobalManager.GetHint(26))
                {
                    DisplayMessage("⑦対戦者達がアリスゲームに参加することになった理由を示す情報は手紙。\n" +
                    "⑧アリスゲームの正体は賭け。");
                }
                else
                {
                    Messagepanel.SetActive(false);
                    Moviepanel.SetActive(true);
                    hintNo = 26;

                }
                break;
        }
      
    }

    public void H1()
    {
        Button = Hinto1;
    }

    public void H2()
    {
        Button = Hinto2;
    }

    public void H3()
    {
        Button = Hinto3;
    }

    public void HK()
    {
        Button = HintoK;
    }

    public void ShowMovie()
    {
        Hintpanel.SetActive(false);
        Moviepanel.SetActive(true);

    }

  

   

    public void MovieEnd(bool flag)
    {
        flowchart.ExecuteBlock("nonmute");

        if (flag == true)
        {
            ShowMessage(20);
         

        }
        else
        {
            DisplayMessage("動画の再生に失敗しました。\n\n" + "※インターネット接続を確認し、しばらくしてから再生してください。");
            Messagepanel.SetActive(true);
          
        }
    }

  
    

    public void ActionMovie()
    {
        Moviepanel.SetActive(false);
        SDKTest.SetMenuObj(this);



        if (SDKTest.m_status == 1)
        {
            if (VAMPUnitySDK.show() == false)
            {
                SDKTest.m_status = 0;
            }
            else
            {
                flowchart.ExecuteBlock("mute");
            }
        }

        if (SDKTest.m_status == 0)
        {

            VAMPUnitySDK.load();

            DisplayMessage("動画の再生に失敗しました。\n\n" + "※インターネット接続を確認し、しばらくしてから再生してください。\n");
            Messagepanel.SetActive(true);
            flowchart.ExecuteBlock("nonmute");


        }
    }

    //メッセージを表示
    void DisplayMessage(string mes)
    {
        Text.GetComponent<Text>().text = mes;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        //バックグラウンド復帰時には音をならす
        if (!pauseStatus)
        {
            flowchart.ExecuteBlock("nonmute");
        }

    }



}
