using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI gameOverMessage;

    [SerializeField]
    Button retryButton;

    [SerializeField]
    Button quitButton;

    [SerializeField]
    TextMeshProUGUI itemMessage;

    //public int itemsCount;      //�t�B�[���h��̃A�C�e�����i�܂��̓N���A�ɕK�v�ȃA�C�e�����j
    //public int collectedItems;  //�v���C���[���擾�����A�C�e����

    //public -> [SerializeField]: �O���̃X�N���v�g����ނ�݂ɒl�������������Ȃ��悤�΍�
    //Unity�@Editor�Œl�m�F������������[SerializeField]������
    [SerializeField]
    int itemsCount;

    [SerializeField]
    int collectedItems;

    //itemsCount�̃v���p�e�B,���ʂȏ����͂��Ȃ�
    public int ItemsCount
    {
        get { return itemsCount; }
        set { itemsCount = value; }
    }

    //collectedItems�̃v���p�e�B

    public int CollectedItems
    {
        get { return collectedItems; }
        set
        {
            //if value���N���A��̐��ȉ����`�F�b�N
            if (value <= itemsCount)
            {
                //�l���X�V
                collectedItems = value;
                //�A�C�e�����擾�������Ɏ��s����������
                //Console�Ɍ��݂̃A�C�e���������\��
                Debug.Log($"�W�߂��A�C�e�����F{collectedItems}");
                //UI��ʂɌ��݂̃A�C�e������\��
                itemMessage.text = $"Items: {collectedItems}";
            }
            //�Q�[���N���A�����𖞂����Ă��邩�`�F�b�N
            if (itemsCount <= value)
            {
                GameOver(true);
            }
        }
    }

    bool playerAlive;// true���@flase��

    public bool PlayerAlive
    {
        get { return playerAlive; }
        set
        {
            playerAlive = value;
            if (!playerAlive)
            {
                GameOver(false);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���I�[�o�[���b�Z�[�W��\��
        gameOverMessage.gameObject.SetActive(false);
        //���g���C�{�^�����\��
        retryButton.gameObject.SetActive(false);

        quitButton.gameObject.SetActive(false);
        //���g���C���̂��߂Ɂ@time.Scale  ��1�ɐݒ肵�Ď��Ԃ𗬂��悤�ɂ���
        Time.timeScale = 1.0f;
        //�}�E�X�J�[�\������ʓ��Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    //void Update()
    //{
    //   //�z�u�����A�C�e�������擾�����A�C�e���������������ꍇ
    //  if(itemsCount <= collectedItems)
    // {
    //     //�Q�[���̃N���A����
    //    GameOver(true);
    //}
    //}

    void GameOver(bool win)
    {
        //Debug.Log("�Q�[���I��");
        if (win)
        {
            //Debug.Log("WIN!");
            gameOverMessage.text = "WIN!";
        }
        else
        {
            //Debug.Log("LOSE...");
            gameOverMessage.text = "LOSE...";
        }
        //�Q�[���I�[�o�[���b�Z�[�W�\��
        gameOverMessage.gameObject.SetActive(true);
        //���g���C�{�^���\��
        retryButton.gameObject.SetActive(true);

        quitButton.gameObject.SetActive(true);
        //�Q�[�����~�߂�
        Time.timeScale = 0.0f;
        //�}�E�X�J�[�\������ʓ��ɕ\������
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Restry()
    {
        //�V�[�����ēǂݍ��݂��čŏ�����n�߂�
        // SceneManager.LoadScene();
        //�w�肵���V�[�����J��
        //��{�I��BuildingSettings����A�v���P�[�V�����Ŏg���V�[����ݒ肵�Ă����K�v������B
        //LoadSceneAsync : ���݂̃V�[�����~�߂��ɔ񓯊��Ŏ��̃V�[���������[�h����
        //                  ���[�h���͍��̃V�[�������삵�����A���[�h����������ƃV�[�����؂�ւ���
        //LoadSceneAsync �̕����֗��ő��p����Ă��邪�A�F�X�ȃe�N�j�b�N������̂Ŋ���

        //SceneManager.LoadScene("MovementTest");       //�V�[�����Ŏw��
        SceneManager.LoadScene(0);                      //�r���h�C���f�b�N�X�Ŏw��  
    }

    public void Quit()
    {
        Application.Quit();
    }
}
