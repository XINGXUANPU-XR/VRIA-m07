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

    //�ǂ�������Ώ�
    [SerializeField]
    private Transform Player_T;

    public GameObject Player;

    public int Hp //�v���p�e�B
    {
        get { return hp; }
        set
        {
            if (0 < hp)
            {
                //�����ϓ�����
                hp = value;
                //Debug.Log($"HP: {hp}");
            }
            if (hp <= 0)
            {
                //���񂾂Ƃ��̏���
                Debug.Log($"{this.name}���S�I");
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
                //bullet�v���n�u��gameObject ����݂őO��1m�@�ɁA
                //�@gameObject�Ɠ��������Ő���
                Instantiate(bulletPrefab,
                            transform.TransformPoint(Vector3.forward),
                            transform.rotation);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //�Ԃ��������肪�v���C���[�̏ꍇ
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



