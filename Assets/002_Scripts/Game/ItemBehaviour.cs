using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class ItemBehaviour : MonoBehaviour
{

    [SerializeField]
    GameManager gameManager;//GameManager　参照用

    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.isTrigger = true;
        }
        //GameManagerをScene内から取得
        //GameObject.Find(ゲームオブジェクト名);
        //指定した名前のゲームオブジェクトを
        //シーンないで検索して見つけたオブジェクトを返す
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //設置アイテム数を更新
        gameManager.ItemsCount += 1;
    }

    void OnTriggerEnter(Collider other)
    {
        //ぶつかってきたのがプレーヤー判定
        //パターン1:相手の名前で判定
        //if(other.name == "Player")
        //パターン2:相手のTagで判定
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("アイテムを取得した");

            //GameManager　のアイテム収集カウントを進める
            gameManager.CollectedItems += 1;

            //Itemのゲームオブジェクトを消す
            Destroy(gameObject);

            //こちらでもOK->gameObject.SetActive(false)は非アクティブ化させる処理
            //gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
