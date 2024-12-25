using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollection : MonoBehaviour
{

    int integer = 1;
    public int[] integers = { 1, 2, 3, 4, 5, };
    // Start is called before the first frame update
    void Start()
    {
        //AccessArrayElements();
        //ArrayInitialization();
        //ArrayWithLoop();

        //ListInitialization();
        //AddAndRemoveListElements();

        ForeachLoop();

    }

    void AccessArrayElements()
    {
        int integer = 1;
        int[] integers = { 1, 2, 3, 4, 5 };

        Debug.Log($"integers[0]  ��   {integers[0]}");
        Debug.Log($"integers[1]  ��   {integers[1]}");
    }

    void ArrayInitialization()
    {
        int[] pattern1;

        pattern1 = new int[5];
        pattern1[0] = 1;
        pattern1[1] = 2;
        pattern1[2] = 3;
        pattern1[3] = 4;
        pattern1[4] = 5;

        int[] pattern2 = new int[5];
        pattern2[0] = 1;
        pattern2[1] = 2;
        pattern2[2] = 3;
        pattern2[3] = 4;
        pattern2[4] = 5;

        int[] pattern3 = new int[] { 1, 2, 3, 4, 5 };
        int[] pattern4 = { 1, 2, 3, 4, 5 };

        int[] pattern5;
        //pattern5 = {1,2,3,4,5}    //�G���[�ɂȂ�
        pattern5 = new int[] { 1, 2, 3, 4, 5 }; //�錾���������𕪂��ď����ꍇ�Anew�@�^��[]���K�v

    }

    void ArrayWithLoop()
    {
        string[] myCarArray = { "Tokyo", "Volvo", "BMW", "Daihatsu", "VM", "Renaut", "Mazda", "Nissan" };

        for(int i=0;i<8;i++)
        {
            Debug.Log(myCarArray[i]);
        }

        for (int i = 0; i < myCarArray.Length; i++)
        {
            Debug.Log(myCarArray[i]);
        }
    }

    void ListInitialization()
    {
        List<string> myCarList = new List<string>() { "Tokyo", "Volvo", "BMW", "Daihatsu", "VM", "Renaut", "Mazda", "Nissan" };

        for(int i = 0 ; i < myCarList.Count ; i++)
        {
            Debug.Log(myCarList[i]);
        }
    }

    void AddAndRemoveListElements()
    {
        List<string> myCarList = new List<string>() { "Tokyo", "Volvo", "BMW", "Daihatsu", "VM", "Renaut", "Mazda", "Nissan" };

        /*myCarList.Add("Mitsubishi");

        for (int i = 0; i < myCarList.Count; i++)
        {
            Debug.Log(myCarList[i]);
        }

        myCarList.Remove("Daihatsu");
        Debug.Log("Daihatsu ���폜");

        for (int i = 0; i < myCarList.Count; i++)
        {
            Debug.Log(myCarList[i]);
        }

        myCarList.RemoveAt(5);
        Debug.Log("�C���f�b�N�X5�̗v�f(Mazda)���폜");

        for (int i = 0; i < myCarList.Count; i++)
        {
            Debug.Log(myCarList[i]);
        }
        
        for (int i = 0; i < myCarList.Count; i++)
        {
            Debug.Log(myCarList[i]);
            if (myCarList[i] == "Renaut")
            {
                myCarList.Remove(myCarList[i]);
            }
        }
        
       
        for (int i = myCarList.Count - 1; i >= 0 ; i--)
        {
            Debug.Log(myCarList[i]);
            if (myCarList[i] == "Renaut")
            {
                myCarList.Remove(myCarList[i]);
            }
        }
        Debug.Log("--------------------------------------");
        for (int i = myCarList.Count - 1; i >= 0; i--)
        {

            Debug.Log(myCarList[i]);
        }
         */
        string[] myCarArray = { "Tokyo", "Volvo", "BMW", "Daihatsu", "VM", "Renaut", "Mazda", "Nissan" };

        for (int i = 0; i < myCarArray.Length; i++)
        {
            if (myCarArray[i] == "Renaut")
            {
                myCarList[i] = "";
            }
            Debug.Log(myCarList[i]);
        }
        


    }

    void ForeachLoop()
    {
        List<string> myCarList = new List<string>() { "Tokyo", "Volvo", "BMW", "Daihatsu", "VM", "Renaut", "Mazda", "Nissan" };

        foreach (string myCar in myCarList) //myCarList���珇�Ԃɗv�f�����o����myCar�ɓ����
        {
            Debug.Log($"����{myCar}�������Ă��܂�"); //myCarList������o�����e�v�f��myCar�Ƃ����ϐ��ő���ł���
        }
        Debug.Log("End of foreach loop");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
