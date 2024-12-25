using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject itemPrefab;

    [SerializeField]
    List<Vector3> itemPositions;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(itemPrefab);  //���_���W�ɐ��������
        // ()���� Oberject �𐶐�����

        // Instantiate(GameObject,�ʒu,����)
        // itemPositions[0]: �ʒu���̃��X�g��0�Ԗڂ̈ʒu��
        // Quaternion.identity:�񓙂����^������������
        //Instantiate(itemPrefab, itemPositions[0], Quaternion.identity);
        
        //var:�ǂ�Ȍ^�ł�����f�[�^�^�B�������A���������K�{
        foreach(var position in itemPositions)
        {
            Instantiate(itemPrefab, position, Quaternion.identity);
        }

        //Destroy():()����GameObject��j������
        Destroy(gameObject);
    }


    
}
