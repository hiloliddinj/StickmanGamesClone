using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;
    public GameManager gameManager;

    public GameObject finishedGameTarggetpoint;

    
    void Start()
    {
        targetOffset = transform.position - target.position;
        gameManager = GameObject.FindWithTag(TagConst.gameManager).GetComponent<GameManager>();
    }


    private void LateUpdate()
    {
        if (!gameManager.isGameFinished)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, .125f);
        } else
        {
            transform.LookAt(target);
            transform.position = Vector3.Lerp(transform.position, finishedGameTarggetpoint.transform.position, .01f);
        }
        
    }
}
