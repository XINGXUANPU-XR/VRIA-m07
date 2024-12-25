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

        //public�ϐ��ɃA�N�Z�X
        Debug.Log($"public�ϐ� {propertyScript.publicNumber}");
        propertyScript.publicNumber = 9999;
        propertyScript.publicNumber += 1;
        Debug.Log($"public�ϐ�{propertyScript.publicNumber}");

        //�A�N�Z�T���\�b�h�Ăяo��
        Debug.Log($"privateNumber{propertyScript.GetNumber()}");
        propertyScript.SetNumber(55);
        Debug.Log($"privateNumber{propertyScript.GetNumber()}");

        //�v���p�e�B���g�p����private�ϐ��ɃA�N�Z�X
        //�v���p�e�B�͌Ăяo����������͕ϐ��̂悤�Ɉ�����(���ۂɂ̓��\�b�h�Ăяo��)
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
            Debug.Log("privateNumber��1�ȏ�100�ȉ��̐����ł�");
            privateNumber = 1;
        }
        else
        {
            Debug.Log("privateNumber��1�ȏ�100�ȉ��̐����ł�");
            privateNumber = 100;
        }
    }
    //�v���p�e�B: �A�N�Z�T���ȒP�ɍ���d�g��
    //�v���p�e�B�̊�{�I�ȏ�����

    //      private �f�[�^�^�@�ϐ���;

    //      pblic �f�[�^�^ �v���p�e�B��(�ϐ����̓�������啶���ɂ���)
    //      {
    //         get
    //          {
    //              //�l���Q�Ƃ���ۂɍs������
    //              return �ϐ���;
    //           }
    //          set
    //           {
    //              //�l��������ۂɍs������
    //              �ϐ��� = value;    //�v���p�e�B�ł�set�̌Ăяo���œn���ꂽ�l���ꗥ��value�Ƃ����ϐ����ň���
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
                Debug.Log("number1��1�ȏ�100�ȉ��̐����ł�");
                number1 = 1;
            }
            else
            {
                Debug.Log("number1��1�ȏ�100�ȉ��̐����ł�");
                number1 = 100;
            }
        }
    }

    //���ʂȏ���������Ȃ��ꍇ�Aget; set; ������{�@}�ň͂�ꂽ�R�[�h�u���b�N���ȗ��ł���
    private int number2;

    public int Number2 { get;set; }

    //�ϐ���錾�����Ƀv���p�e�B�����ł�OK
    //���̏ꍇ�A�R���p�C�����Ɏ����I�ɕϐ����쐬�����i���̕ϐ��͏����Ă���v���O��������͌����Ȃ��j

    //private int number3;  //<-�R���p�C����������������̂ō�炭�Ă���

    public int Number3 {  get;set; }

    //get�� set�ŃA�N�Z�X���x���͕ς���

    public int Number4 { get;private set; }
    
    //�R���X�g���N�^�̎g�p���񐄑E
    public int Number5 { get; }

    public int Number6
    {
        get
        {
            return Number6;//������get���Ăяo�����
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
