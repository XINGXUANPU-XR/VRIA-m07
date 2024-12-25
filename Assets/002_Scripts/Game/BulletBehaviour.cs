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
        Debug.Log("Bullet����");
        rb = GetComponent<Rigidbody>();

        //�d�͂𖳌��ɂ���
        rb.useGravity = false;

        //Rigidbody �̑��x(velocity)��ݒ肵�đO���ɔ�΂�
        //�@velocity�@�͂��̂悤�ɏ��������߂�̂ɂ͕֗������A
        // �ړ����̃I�u�W�F�N�g��velocity�@��ҏW����ƕs���R�ȓ����ɂȂ�̂Œ���
        rb.velocity = transform.forward * speed;

        //OnTriggerEnter ���g�p�������̂ŃR���C�_�[��isTrigger���I���ɂ���
        GetComponent<Collider>().isTrigger = true;

        //Destroy�̑�2������float�l��n���ƁA�l�Ŏw�肵�����Ԍ�ɏ�����
        Destroy(gameObject, destroyTimer);  
    }

    private void OnTriggerEnter(Collider other)
    {
        //���̃I�u�W�F�N�g�ɂԂ������������
        Destroy(gameObject);
        Debug.Log($"{other.gameObject.name}�ɖ����I");

        //�Ԃ��������肪�v���C���[�̏ꍇ
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
