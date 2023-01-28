using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubPlayer : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(TagConst.gameManager).GetComponent<GameManager>().targetPoint;
    }

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }
}
