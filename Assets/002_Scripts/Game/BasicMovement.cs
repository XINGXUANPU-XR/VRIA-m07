using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BasicMovement : MonoBehaviour
{

    [SerializeField]
    private bool WasPressedThisFrameMovement;

    [SerializeField]
    private bool IsPressedMovement;

    [SerializeField]
    private float movementSpeed = 3.0f;

    //Vetor3 vetor3Varible;  //これまでの変数と同様に変数宣言できる
    Vector3 vetor3Varible = new Vector3(1.0f, 2.0f, 3.0f);

    float playerSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInfo();

        //transform.positionの位置を
        //(X,Y,Z) = (1.0f,1.0f,1.0f)へ移動
        //transform.position = new Vector3(1.0f, 1.0f, 1.0f);

        //transform.position.x = 1.0f; //エラー：このように代入することができない
        //transform.position.y = 1.0f; //エラー：このように代入することができない
        //transform.position.z = 1.0f; //エラー：このように代入することができない

        //Vetor3のよく使う値
        //transform.position = vector3.zero;       //Vector3.zero  =   (0.0f,0.0f,0.0f);
        //transform.position = vector3.one;        //Vector3.one  =   (1.0f,1.0f,1.0f);
        //transform.position = vector3.right;      //Vector3.right  =   (1.0f,0.0f,0.0f);
        //transform.position = vector3.up;         //Vector3.up  =   (0.0f,1.0f,0.0f);
        //transform.position = vector3.forward;    //Vector3.forward  =   (0.0f,0.0f,1.0f);

        //Transform.positionと違い、それぞれの値を個別に変更できる
        Vector3 vect3Vari = new Vector3(1.0f, 2.0f, 3.0f);
        vect3Vari.x = 5.0f;                 //個別に代入できる
        vect3Vari.y = 5.0f;                 //個別に代入できる    
        vect3Vari.z = 5.0f;                 //個別に代入できる    
        transform.position = vect3Vari;     //個別変更したvect3Variをtransform.positionni代入する  

        transform.position = Vector3.one;   //Playerの座標を(1.0f,1.0f,1.0f)にリセット
        //transform.position = transform.position + new Vector3(1.0f, 1.0f, 1.0f);
        transform.position += Vector3.one;        //(2,2,2)
        //transform.position += Vector3.right;      //(2,1,1)
        //transform.position += Vector3.up;         //(1,2,1)
        //transform.position += Vector3.forward;    //(1,1,2)


        //Vector3 での座標はfloat型とした認識される
        //Vector3 normalVector3 = new Vector3(1, 2, 3);

        //Vector3Int での座標はint型とした認識される
        //Vector3 normalIntVaribale = new Vector3Int(1, 2, 3);


    }

    // Update is called once per frame
    void Update()
    {
        if (WasPressedThisFrameMovement) wasPressedThisFrameMovement();
        else if (IsPressedMovement)           isPressedMovement(); 
        //isPressedMovement();
        //wasPressedThisFrameMovement();
    }

    void wasPressedThisFrameMovement()
    {
        //今使ったキーボードのwキーを1回押したとき
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("wキーが押されました");
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("aキーが押されました");
            transform.position += Vector3.right * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Debug.Log("sキーが押されました");
            transform.position += Vector3.forward * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Debug.Log("dキーが押されました");
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }

    void isPressedMovement()
    {
        //今使ったキーボードのwキーを押す間ずっと
        if (Keyboard.current.wKey.isPressed)
        {
            Debug.Log("wキーが押されました");
            transform.position += Vector3.forward /* playerSpeed */* Time.deltaTime * movementSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("aキーが押されました");
            transform.position += Vector3.right * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            Debug.Log("sキーが押されました");
            transform.position += Vector3.forward * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("dキーが押されました");
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }

    void GetComponentInfo()
    {
        //gameObject:スクリプトがついている　GameObjectへアクセスする  
        Debug.Log(gameObject.name);//オブジェクト名を参照して出力する

        //GetComponent<Transform>()：<>内で指定したComponent(Transform)の情報を取得する
        Debug.Log(gameObject.GetComponent<Transform>().position);

        //transform:スクリプトがついている　Transformへアクセスする(GetComponent 無しで)
        Debug.Log(gameObject.transform.position);

        //同一オブジェクトにあるコンポーネントへアクセスする際に、gameObject.　は省略可能
        //Debug.Log(transform.position);
    }

    
}
