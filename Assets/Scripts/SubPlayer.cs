using UnityEngine;
using UnityEngine.AI;

public class SubPlayer : MonoBehaviour
{
    GameObject target;
    GameManager gameManager;
    NavMeshAgent navMeshAgent;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

        } else if (other.CompareTag(TagConst.defender))
        {
            gameManager.realTimePlayerCount--;
            gameObject.SetActive(false);
            animator.SetBool(AnimeConst.isRunning, false);
        }

        
    }
}
