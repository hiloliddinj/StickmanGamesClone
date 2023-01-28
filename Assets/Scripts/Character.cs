using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        var dir = new Vector3(Input.GetAxis(ControlConst.horizontal), 0, 1);
        transform.Translate(speed * Time.deltaTime * dir);
    }
}
