using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameManager gameManager;

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
        var dir = new Vector3(Input.GetAxis(ControlConst.horizontal) - 0.2f, 0, 1);//- 0.2ff added because my character was going a bit to right because of wrong animation turn
        transform.Translate(speed * Time.deltaTime * dir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.multiplication) || other.CompareTag(TagConst.addition))
        {
            int amount = int.Parse(other.name);
            gameManager.SubCharacterManagement(other.tag, amount, other.transform);
            Debug.Log("Carpti: " + other.name);
        }
    }
}
