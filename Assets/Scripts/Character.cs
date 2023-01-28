using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag(TagConst.gameManager).GetComponent<GameManager>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(Input.GetAxis(ControlConst.mouseX) < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
            }
            if (Input.GetAxis(ControlConst.mouseX) > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!gameManager.isDefenderDead)
        {
            var dir = new Vector3(Input.GetAxis(ControlConst.horizontal) - 0.2f, 0, 1);//- 0.2ff added because my character was going a bit to right because of wrong animation turn
            transform.Translate(speed * Time.deltaTime * dir);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.multiplication) || other.CompareTag(TagConst.addition))
        {
            int amount = int.Parse(other.name);
            gameManager.SubCharacterManagement(other.tag, amount, other.transform);
            Debug.Log("Carpti: " + other.name);
        }

        if (other.CompareTag(TagConst.wall))
        {
            speed = .7f;
            if (other.name == "1")
            {
                Debug.Log("Character, Wall 1");
                gameManager.realTimeEnemyCount = gameManager.wall1Enemies.Count;
                foreach (var enemy in gameManager.wall1Enemies)
                {
                    enemy.GetComponent<Enemy>().isPlayersNear = true;
                }

            } else if (other.name == "2")
            {
                gameManager.realTimeEnemyCount = gameManager.wall2Enemies.Count;
                Debug.Log("Character, Wall 2");
                foreach (var enemy in gameManager.wall2Enemies)
                {
                    enemy.GetComponent<Enemy>().isPlayersNear = true;
                }
            }
        }

        if (other.CompareTag(TagConst.endWall))
        {
            speed = 2f;
        }

        if (other.CompareTag(TagConst.bonusWall))
        {
            gameManager.DefenderStartWalk();
            speed = 1.5f;
            gameManager.isGameFinished = true;
        }

    }
}
