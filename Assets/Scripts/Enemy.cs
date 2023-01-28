using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject target;
    GameManager gameManager;
    public bool isPlayersNear = false;

    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindWithTag(TagConst.gameManager).GetComponent<GameManager>();
        target = gameManager.targetPoint;
    }

    private void FixedUpdate()
    {
        if (isPlayersNear)
        {
            animator.SetBool(AnimeConst.isRunning, true);
            transform.LookAt(target.transform.position);
            transform.position = Vector3.Lerp(transform.position, target.transform.position, .01f);
            Debug.Log("Enemy, Enemy is near!!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.subPlayer))
        {
            Debug.Log("Enemy, Enemy Died");
            gameManager.realTimeEnemyCount--;
            gameObject.SetActive(false);

            
        }
    }


}
