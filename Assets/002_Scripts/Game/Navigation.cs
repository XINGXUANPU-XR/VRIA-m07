using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    //�ǂ�������Ώ�
    [SerializeField]
    private Transform Player;

    void Update()
    {
        navMeshAgent.SetDestination(Player.position);
    }
}
