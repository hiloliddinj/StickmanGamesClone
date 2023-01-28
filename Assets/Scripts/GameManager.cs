using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject target;
    public GameObject prefabCharacter;
    public GameObject birthPoint;
    public GameObject targetPoint;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(prefabCharacter, birthPoint.transform.position, Quaternion.identity);
        }
    }
}
