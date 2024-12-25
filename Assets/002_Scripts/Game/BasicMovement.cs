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

    //Vetor3 vetor3Varible;  //����܂ł̕ϐ��Ɠ��l�ɕϐ��錾�ł���
    Vector3 vetor3Varible = new Vector3(1.0f, 2.0f, 3.0f);

    float playerSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInfo();

        //transform.position�̈ʒu��
        //(X,Y,Z) = (1.0f,1.0f,1.0f)�ֈړ�
        //transform.position = new Vector3(1.0f, 1.0f, 1.0f);

        //transform.position.x = 1.0f; //�G���[�F���̂悤�ɑ�����邱�Ƃ��ł��Ȃ�
        //transform.position.y = 1.0f; //�G���[�F���̂悤�ɑ�����邱�Ƃ��ł��Ȃ�
        //transform.position.z = 1.0f; //�G���[�F���̂悤�ɑ�����邱�Ƃ��ł��Ȃ�

        //Vetor3�̂悭�g���l
        //transform.position = vector3.zero;       //Vector3.zero  =   (0.0f,0.0f,0.0f);
        //transform.position = vector3.one;        //Vector3.one  =   (1.0f,1.0f,1.0f);
        //transform.position = vector3.right;      //Vector3.right  =   (1.0f,0.0f,0.0f);
        //transform.position = vector3.up;         //Vector3.up  =   (0.0f,1.0f,0.0f);
        //transform.position = vector3.forward;    //Vector3.forward  =   (0.0f,0.0f,1.0f);

        //Transform.position�ƈႢ�A���ꂼ��̒l���ʂɕύX�ł���
        Vector3 vect3Vari = new Vector3(1.0f, 2.0f, 3.0f);
        vect3Vari.x = 5.0f;                 //�ʂɑ���ł���
        vect3Vari.y = 5.0f;                 //�ʂɑ���ł���    
        vect3Vari.z = 5.0f;                 //�ʂɑ���ł���    
        transform.position = vect3Vari;     //�ʕύX����vect3Vari��transform.positionni�������  

        transform.position = Vector3.one;   //Player�̍��W��(1.0f,1.0f,1.0f)�Ƀ��Z�b�g
        //transform.position = transform.position + new Vector3(1.0f, 1.0f, 1.0f);
        transform.position += Vector3.one;        //(2,2,2)
        //transform.position += Vector3.right;      //(2,1,1)
        //transform.position += Vector3.up;         //(1,2,1)
        //transform.position += Vector3.forward;    //(1,1,2)


        //Vector3 �ł̍��W��float�^�Ƃ����F�������
        //Vector3 normalVector3 = new Vector3(1, 2, 3);

        //Vector3Int �ł̍��W��int�^�Ƃ����F�������
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
        //���g�����L�[�{�[�h��w�L�[��1�񉟂����Ƃ�
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("w�L�[��������܂���");
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("a�L�[��������܂���");
            transform.position += Vector3.right * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Debug.Log("s�L�[��������܂���");
            transform.position += Vector3.forward * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Debug.Log("d�L�[��������܂���");
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }

    void isPressedMovement()
    {
        //���g�����L�[�{�[�h��w�L�[�������Ԃ�����
        if (Keyboard.current.wKey.isPressed)
        {
            Debug.Log("w�L�[��������܂���");
            transform.position += Vector3.forward /* playerSpeed */* Time.deltaTime * movementSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("a�L�[��������܂���");
            transform.position += Vector3.right * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            Debug.Log("s�L�[��������܂���");
            transform.position += Vector3.forward * (-1) * playerSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("d�L�[��������܂���");
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
    }

    void GetComponentInfo()
    {
        //gameObject:�X�N���v�g�����Ă���@GameObject�փA�N�Z�X����  
        Debug.Log(gameObject.name);//�I�u�W�F�N�g�����Q�Ƃ��ďo�͂���

        //GetComponent<Transform>()�F<>���Ŏw�肵��Component(Transform)�̏����擾����
        Debug.Log(gameObject.GetComponent<Transform>().position);

        //transform:�X�N���v�g�����Ă���@Transform�փA�N�Z�X����(GetComponent ������)
        Debug.Log(gameObject.transform.position);

        //����I�u�W�F�N�g�ɂ���R���|�[�l���g�փA�N�Z�X����ۂɁAgameObject.�@�͏ȗ��\
        //Debug.Log(transform.position);
    }

    
}
