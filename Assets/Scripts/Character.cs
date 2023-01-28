using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        var dir = new Vector3(Input.GetAxis(ControlConst.horizontal) - 0.2f, 0, 1);//- 0.2ff added because my character was going a bit to right because of wrong animation turn
        transform.Translate(speed * Time.deltaTime * dir);
    }
}
