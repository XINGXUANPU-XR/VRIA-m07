using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI gameOverMessage;

    [SerializeField]
    Button retryButton;

    [SerializeField]
    Button quitButton;

    [SerializeField]
    TextMeshProUGUI itemMessage;

    //public int itemsCount;      //フィールド上のアイテム数（またはクリアに必要なアイテム数）
    //public int collectedItems;  //プレイヤーが取得したアイテム数

    //public -> [SerializeField]: 外部のスクリプトからむやみに値を書き換えられないよう対策
    //Unity　Editorで値確認だけしたい為[SerializeField]をつけた
    [SerializeField]
    int itemsCount;

    [SerializeField]
    int collectedItems;

    //itemsCountのプロパティ,特別な処理はしない
    public int ItemsCount
    {
        get { return itemsCount; }
        set { itemsCount = value; }
    }

    //collectedItemsのプロパティ

    public int CollectedItems
    {
        get { return collectedItems; }
        set
        {
            //if valueがクリア基準の数以下かチェック
            if (value <= itemsCount)
            {
                //値を更新
                collectedItems = value;
                //アイテムを取得した時に実行したい処理
                //Consoleに現在のアイテム数をお表示
                Debug.Log($"集めたアイテム数：{collectedItems}");
                //UI画面に現在のアイテム数を表示
                itemMessage.text = $"Items: {collectedItems}";
            }
            //ゲームクリア条件を満たしているかチェック
            if (itemsCount <= value)
            {
                GameOver(true);
            }
        }
    }

    bool playerAlive;// true生　flase死

    public bool PlayerAlive
    {
        get { return playerAlive; }
        set
        {
            playerAlive = value;
            if (!playerAlive)
            {
                GameOver(false);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //ゲームオーバーメッセージ非表示
        gameOverMessage.gameObject.SetActive(false);
        //リトライボタンを非表示
        retryButton.gameObject.SetActive(false);

        quitButton.gameObject.SetActive(false);
        //リトライ時のために　time.Scale  を1に設定して時間を流れるようにする
        Time.timeScale = 1.0f;
        //マウスカーソルを画面内にロックする
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    //void Update()
    //{
    //   //配置したアイテム数より取得したアイテム数が多かった場合
    //  if(itemsCount <= collectedItems)
    // {
    //     //ゲームのクリア処理
    //    GameOver(true);
    //}
    //}

    void GameOver(bool win)
    {
        //Debug.Log("ゲーム終了");
        if (win)
        {
            //Debug.Log("WIN!");
            gameOverMessage.text = "WIN!";
        }
        else
        {
            //Debug.Log("LOSE...");
            gameOverMessage.text = "LOSE...";
        }
        //ゲームオーバーメッセージ表示
        gameOverMessage.gameObject.SetActive(true);
        //リトライボタン表示
        retryButton.gameObject.SetActive(true);

        quitButton.gameObject.SetActive(true);
        //ゲームを止める
        Time.timeScale = 0.0f;
        //マウスカーソルを画面内に表示する
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Restry()
    {
        //シーンを再読み込みして最初から始める
        // SceneManager.LoadScene();
        //指定したシーンを開く
        //基本的にBuildingSettingsからアプリケーションで使うシーンを設定しておく必要がある。
        //LoadSceneAsync : 現在のシーンを止めずに非同期で次のシーンうぃロードする
        //                  ロード中は今のシーンが動作し続け、ロードが完了するとシーンが切り替われる
        //LoadSceneAsync の方が便利で多用されているが、色々なテクニックがあるので割愛

        //SceneManager.LoadScene("MovementTest");       //シーン名で指定
        SceneManager.LoadScene(0);                      //ビルドインデックスで指定  
    }

    public void Quit()
    {
        Application.Quit();
    }
}
