using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKTest : MonoBehaviour, VAMPUnitySDK.IVAMPListener, VAMPUnitySDK.IVAMPAdvancedListener
{
#if UNITY_IOS
	//iOS用のページIDをセット
	private const string placementID = "77166";
#elif UNITY_ANDROID
    //Android用のページIDをセット
    private const string placementID = "77123";
#endif


    static public LoadObject loadObj;
    static public TitleManager titlemgr;
    static public GameMenu menuObj;
    static bool titleflag;
    static bool loadflag;
    static bool menuflag;
    static public int m_status;
    static public bool completeflag;

    void Start()
    {
        
        titleflag = false;
        loadflag = false;
        m_status = 0;
        completeflag = false;

        // ~~~ VAMP初期化 ~~~
        // trueを指定すると収益が発生しないテスト広告が配信されるようになります。
        // ストアに申請する際は必ずfalseを設定してください
        VAMPUnitySDK.setTestMode(false);

        // trueを指定するとログを詳細に出力するデバッグモードになります
        VAMPUnitySDK.setDebugMode(false);

        // VAMPを初期化します。必ずLoadより先に実行してください
        VAMPUnitySDK.initialize(placementID);

        // リスナーを設定します
        VAMPUnitySDK.setVAMPListener(this);
        VAMPUnitySDK.setAdvancedListener(this);

        DontDestroyOnLoad(this);



        // 動画広告がまだ準備されていないときはロードを開始します
        VAMPUnitySDK.load();
    }

   

    static public void Initialize()
    {
        VAMPUnitySDK.initialize(placementID);
        VAMPUnitySDK.load();
    }
    // IVAMPListener
    public void VAMPDidReceive(string placementId, string adnwName)
    {
        // 広告表示の準備完了
        Debug.LogFormat("[VAMPUnitySDK] VAMPDidReceive: {0} {1}", placementId, adnwName);
        m_status = 1;
        
      
        // 広告表示
       //  VAMPUnitySDK.show();
    }

    static public void SetTitleMovieObj(TitleManager obj)
    {
        titlemgr = obj;
        titleflag = true;
        loadflag = false;
        menuflag = false;
    }

    static public void SetLoadMovieObj(LoadObject obj)
    {
        loadObj = obj;
        titleflag = false;
        loadflag = true;
        menuflag = false;
    }

    static public void SetMenuObj(GameMenu obj)
    {
        menuObj = obj;
        menuflag = true;
        titleflag = false;
        loadflag = false;
    }
  
    public void VAMPDidFailToLoad(VAMPUnitySDK.VAMPError error, string placementId)
    {
        // 広告準備に失敗
   //     Debug.LogFormat("[VAMPUnitySDK] VAMPDidFailToLoad: {0} {1}", error, placementId);
        m_status = 0;
        StartCoroutine(_onEnd());

    }

    public void VAMPDidFailToShow(VAMPUnitySDK.VAMPError error, string placementId)
    {
        // 動画の表示に失敗
    //    Debug.LogFormat("[VAMPUnitySDK] VAMPDidFailToShow: {0} {1}", error, placementId);
        m_status = 0;
        StartCoroutine(_onEnd());
     
    }

    public void VAMPDidComplete(string placementId, string adnwName)
    {
        // 動画再生正常終了（インセンティブ付与可能）
     //   Debug.LogFormat("[VAMPUnitySDK] VAMPDidComplete: {0} {1}", placementId, adnwName);
        completeflag = true;


        // VAMPUnitySDK.load();
    }

    public void VAMPDidClose(string placementId, string adnwName)
    {
        // 動画プレーヤーやエンドカードが表示終了
        // ＜注意：ユーザキャンセルなども含むので、インセンティブ付与はonCompleteで判定すること＞
     //   Debug.LogFormat("[VAMPUnitySDK] VAMPDidClose: {0} {1}", placementId, adnwName);
        m_status = 0;
        StartCoroutine(_onEnd());
       
      
        //  VAMPUnitySDK.load();
    }

    private IEnumerator _onEnd()
    {

        yield return new WaitForSeconds(0.5f);
        // オーディオを鳴らすなどの終了処理をここに書く
        if (m_status == 0 )
        {
          
            Debug.LogFormat("load");
            VAMPUnitySDK.load();
        }

        if (titleflag)
        {
            titleflag = false;
            titlemgr.MovieEnd(completeflag);
            completeflag = false;

        }
        else if (loadflag)
        {
            loadflag = false;        
            loadObj.MovieEnd(completeflag);
            completeflag = false;


        }
        else if (menuflag)
        {
            menuflag = false;
            menuObj.MovieEnd(completeflag);
            completeflag = false;


        }


    }

    public void VAMPDidExpired(string placementId)
    {
        // 有効期限オーバー
        // ＜注意：onReceiveを受けてからの有効期限が切れました。showするには再度loadを行う必要が有ります＞
        Debug.LogFormat("[VAMPUnitySDK] VAMPDidExpired: {0}", placementId);
       // VAMPUnitySDK.load();
    }

    // IVAMPAdvancedListener
    public void VAMPLoadStart(string placementId, string adnwName)
    {
        // 優先順位順にアドネットワークごとの広告取得を開始
        Debug.LogFormat("[VAMPUnitySDK] VAMPLoadStart: {0} {1}", placementId, adnwName);
    }

    public void VAMPLoadResult(string placementId, bool success, string adnwName, string message)
    {
        // アドネットワークごとの広告取得結果
        Debug.LogFormat("[VAMPUnitySDK] VAMPLoadResult: {0} {1} {2} {3}", placementId, success, adnwName, message);
    }

}
