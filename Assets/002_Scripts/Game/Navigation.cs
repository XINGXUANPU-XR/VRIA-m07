using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    //追いかける対象
    [SerializeField]
    private Transform Player;

    void Update()
    {
        navMeshAgent.SetDestination(Player.position);
    }
}
