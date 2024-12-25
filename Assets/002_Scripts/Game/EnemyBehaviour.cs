using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform muzzlePosition;

    [SerializeField]
    private int hp = 5;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    //追いかける対象
    [SerializeField]
    private Transform Player_T;

    public GameObject Player;

    public int Hp //プロパティ
    {
        get { return hp; }
        set
        {
            if (0 < hp)
            {
                //ｈｐ変動処理
                hp = value;
                //Debug.Log($"HP: {hp}");
            }
            if (hp <= 0)
            {
                //死んだときの処理
                Debug.Log($"{this.name}死亡！");
                Destroy(gameObject);

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    float timer = 0.0f;
    float threshold = 0.5f;

    void Update()
    {


        if (timer < Time.time)
        {
            Attack();

            timer += threshold;
        }
    }

    float disatance;
    void Attack()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= 10)
        {
            navMeshAgent.SetDestination(Player_T.position);

            if (muzzlePosition != null)
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
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //ぶつかった相手がプレイヤーの場合
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            player.Hp -= 1;

            return;
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            enemy.Hp -= 1;
            return;
        }

    }
}



