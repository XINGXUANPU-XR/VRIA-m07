using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropertyTest : MonoBehaviour
{

    [SerializeField]
    private PropertyTest propertyScript;

    public int publicNumber = 0;

    public int privateNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(propertyScript == null)
        {
            propertyScript = GetComponent<PropertyTest>();
        }

        //public変数にアクセス
        Debug.Log($"public変数 {propertyScript.publicNumber}");
        propertyScript.publicNumber = 9999;
        propertyScript.publicNumber += 1;
        Debug.Log($"public変数{propertyScript.publicNumber}");

        //アクセサメソッド呼び出し
        Debug.Log($"privateNumber{propertyScript.GetNumber()}");
        propertyScript.SetNumber(55);
        Debug.Log($"privateNumber{propertyScript.GetNumber()}");

        //プロパティを使用してprivate変数にアクセス
        //プロパティは呼び出した側からは変数のように扱える(実際にはメソッド呼び出し)
        Debug.Log($"privateNumber{propertyScript.Number1}");
        propertyScript.Number1 = 50;
        Debug.Log($"privateNumber{propertyScript.Number1}");
        propertyScript.Number1 *= 3;
        Debug.Log($"privateNumber{propertyScript.Number1}");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetNumber()
    {
        return privateNumber;
    }

    public void SetNumber(int value)
    {
        if((0 < value)&&(value < 101))
        {
            privateNumber = value;
        }
        else if(value <= 0)
        {
            Debug.Log("privateNumberは1以上100以下の整数です");
            privateNumber = 1;
        }
        else
        {
            Debug.Log("privateNumberは1以上100以下の整数です");
            privateNumber = 100;
        }
    }
    //プロパティ: アクセサを簡単に作れる仕組み
    //プロパティの基本的な書き方

    //      private データ型　変数名;

    //      pblic データ型 プロパティ名(変数名の頭文字を大文字にする)
    //      {
    //         get
    //          {
    //              //値を参照する際に行う処理
    //              return 変数名;
    //           }
    //          set
    //           {
    //              //値を代入する際に行う処理
    //              変数名 = value;    //プロパティではsetの呼び出しで渡された値を一律でvalueという変数名で扱う
    //           }
    //       }

    private int number1;

    public int Number1
    {
        get
        {
            return number1;
        }
        set
        {
            if((0 < value) && (value < 101))
            {
                number1 = value;
            }
            else if(value <= 0 )
            {
                Debug.Log("number1は1以上100以下の整数です");
                number1 = 1;
            }
            else
            {
                Debug.Log("number1は1以上100以下の整数です");
                number1 = 100;
            }
        }
    }

    //特別な処理がいらない場合、get; set; だけで{　}で囲われたコードブロックを省略できる
    private int number2;

    public int Number2 { get;set; }

    //変数を宣言せずにプロパティだけでもOK
    //この場合、コンパイル時に自動的に変数が作成される（この変数は書いているプログラムからは見えない）

    //private int number3;  //<-コンパイラが自動生成するので作らくていい

    public int Number3 {  get;set; }

    //getと setでアクセスレベルは変える

    public int Number4 { get;private set; }
    
    //コンストラクタの使用が非推薦
    public int Number5 { get; }

    public int Number6
    {
        get
        {
            return Number6;//無限にgetが呼び出される
        }
        set
        {
            if(0 < value)
            {
                Number6 = value;
            }
        }
    }
}
