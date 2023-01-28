using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject targetPoint;
    public int realTimePlayerCount = 1;
    public int realTimeEnemyCount = 0;
    public GameObject player;
    public GameObject defender;
    public bool isGameFinished = false;
    public bool isDefenderDead = false;

    public List<GameObject> playerList;
    public List<GameObject> wall1Enemies;
    public List<GameObject> wall2Enemies;


    void Start()
    {
        player = GameObject.FindWithTag(TagConst.player);
        defender = GameObject.FindWithTag(TagConst.defender);
    }

    
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.X))
        //{
        //    foreach(var subPlayer in playerList)
        //    {
        //        if (!subPlayer.activeInHierarchy)
        //        {
        //            subPlayer.transform.position = birthPoint.transform.position;
        //            subPlayer.SetActive(true);
        //            realTimePlayerCount++;
        //            break;
        //        }
        //    }
        //}
    }

    private void FixedUpdate()
    {
        if (realTimeEnemyCount > realTimePlayerCount)
        {
            player.SetActive(false);
            //foreach (var subPlayer in gameManager.playerList)
            //{
            //    if (subPlayer.activeInHierarchy)
            //    {
            //        subPlayer.SetActive(false);
            //    }
            //}

            Debug.Log("YOU LOOSE !!!!!");
        }
    }

    public void SubCharacterManagement(string operationType, int amount, Transform transform)
    {
        switch(operationType)
        {
            case TagConst.addition:
                int value2 = 0;
                foreach (var subPlayer in playerList)
                {
                    if (value2 < amount)
                    {
                        if (!subPlayer.activeInHierarchy)
                        {
                            subPlayer.transform.position = transform.position;
                            subPlayer.SetActive(true);
                            value2++;
                        }
                    }
                    else
                    {
                        value2 = 0;
                        break;
                    }


                }
                realTimePlayerCount += amount;
                break;

            case TagConst.multiplication:
                int value = 0;

                int maxAmount = amount * realTimePlayerCount;

                foreach (var subPlayer in playerList)
                {

                    if (value < maxAmount)
                    {
                        if (!subPlayer.activeInHierarchy)
                        {
                            subPlayer.transform.position = transform.position;
                            subPlayer.SetActive(true);
                            value++;
                         
                        }
                    } else
                    {
                        value = 0;
                        break;
                    }

                    
                }
                realTimePlayerCount *= amount;
                break;
        }
    }

    public void DefenderStartWalk()
    {
        defender.GetComponent<Defender>().didComePlayers = true;
    }
}
