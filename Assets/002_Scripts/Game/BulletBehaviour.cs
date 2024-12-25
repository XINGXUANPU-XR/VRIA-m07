using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]

public class BulletBehaviour : MonoBehaviour
{

    public float speed = 5.0f;
    public float destroyTimer = 5.0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bullet発射");
        rb = GetComponent<Rigidbody>();

        //重力を無効にする
        rb.useGravity = false;

        //Rigidbody の速度(velocity)を設定して前方に飛ばす
        //　velocity　はこのように初速を決めるのには便利だが、
        // 移動中のオブジェクトのvelocity　を編集すると不自然な動きになるので注意
        rb.velocity = transform.forward * speed;

        //OnTriggerEnter を使用したいのでコライダーのisTriggerをオンにする
        GetComponent<Collider>().isTrigger = true;

        //Destroyの第2引数にfloat値を渡すと、値で指定した時間後に消える
        Destroy(gameObject, destroyTimer);  
    }

    private void OnTriggerEnter(Collider other)
    {
        //他のオブジェクトにぶつかったら消える
        Destroy(gameObject);
        Debug.Log($"{other.gameObject.name}に命中！");

        //ぶつかった相手がプレイヤーの場合
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            player.Hp -= 1;

            return;
        }

        else if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            enemy.Hp -= 1;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
