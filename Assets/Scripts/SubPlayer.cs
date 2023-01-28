using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubPlayer : MonoBehaviour
{
    GameObject target;
    GameManager gameManager;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        gameManager = GameObject.FindWithTag(TagConst.gameManager).GetComponent<GameManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = gameManager.targetPoint;
    }

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.obstacle) || other.CompareTag(TagConst.enemy))
        {
            Debug.Log("SubLpayer, Player Died");
            gameManager.realTimePlayerCount--;
            gameObject.SetActive(false);
        }
    }
}
