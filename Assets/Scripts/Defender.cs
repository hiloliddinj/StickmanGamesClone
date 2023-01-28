using UnityEngine;

public class Defender : MonoBehaviour
{
    GameObject target;
    GameManager gameManager;
    private float life = 10;

    Animator animator;
    public bool didComePlayers = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindWithTag(TagConst.gameManager).GetComponent<GameManager>();
        target = gameManager.targetPoint;
    }

    private void FixedUpdate()
    {
        if (didComePlayers)
        {
            animator.SetBool(AnimeConst.isWalking, true);
            transform.LookAt(target.transform.position);
            transform.position = Vector3.Lerp(transform.position, target.transform.position, .001f);
            Debug.Log("Defender, Player came !!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.subPlayer) || other.CompareTag(TagConst.player))
        {
            animator.SetBool(AnimeConst.isAttacking, true);
        }

        if (life > 0)
        {
            other.gameObject.SetActive(false);
            gameManager.realTimePlayerCount--;
            life--;
        } else
        {
            animator.SetBool(AnimeConst.isDiying, true);
            gameManager.player.GetComponent<Animator>().SetBool(AnimeConst.isRunning, false);
            gameManager.isDefenderDead = true;
            
        } 
    }
}
