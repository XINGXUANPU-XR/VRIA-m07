using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    TextMeshProUGUI hpMessage;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject bulletPrefabPos;

    [SerializeField]
    Transform muzzlePosition;

    [SerializeField]
    private int hp = 5;

    public int Hp //プロパティ
    {
        get { return hp; }
        set 
        {
            if(0 < hp)
            {
                //ｈｐ変動処理
                hp= value;
                //Debug.Log($"HP: {hp}");
                hpMessage.text = $"HP: {hp}";
                gameManager.PlayerAlive = true;
            }
            if(hp <= 0)
            {
                //死んだときの処理
                Debug.Log("死亡！");
                gameManager.PlayerAlive = false;

            }
        }
    }

    public void OnFire(InputValue imputValue)
    {
        //this.Hp-=1;　//デバッグ用：自傷ダメージ

        if(muzzlePosition != null)
        {
            var bulletObject = Instantiate(bulletPrefab, muzzlePosition.position, transform.rotation);
        }
        else
        {
            //bulletプレハブをgameObject からみで前方1m　に、
            //　gameObjectと同じ向きで生成
            Instantiate(bulletPrefab,
                       transform.TransformPoint(Vector3.forward),
                     transform.rotation);

            //GameObject temp = Instantiate(bulletPrefab, bulletPrefabPos.transform.position, Quaternion.identity);   

            //temp.GetComponent<Rigidbody>().AddForce(transform.forward * 800);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        //HP初期値
        Hp = hp;
        bulletPrefabPos = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
