using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class ItemBehaviour : MonoBehaviour
{

    [SerializeField]
    GameManager gameManager;//GameManager�@�Q�Ɨp

    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.isTrigger = true;
        }
        //GameManager��Scene������擾
        //GameObject.Find(�Q�[���I�u�W�F�N�g��);
        //�w�肵�����O�̃Q�[���I�u�W�F�N�g��
        //�V�[���Ȃ��Ō������Č������I�u�W�F�N�g��Ԃ�
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //�ݒu�A�C�e�������X�V
        gameManager.ItemsCount += 1;
    }

    void OnTriggerEnter(Collider other)
    {
        //�Ԃ����Ă����̂��v���[���[����
        //�p�^�[��1:����̖��O�Ŕ���
        //if(other.name == "Player")
        //�p�^�[��2:�����Tag�Ŕ���
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("�A�C�e�����擾����");

            //GameManager�@�̃A�C�e�����W�J�E���g��i�߂�
            gameManager.CollectedItems += 1;

            //Item�̃Q�[���I�u�W�F�N�g������
            Destroy(gameObject);

            //������ł�OK->gameObject.SetActive(false)�͔�A�N�e�B�u�������鏈��
            //gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
