using UnityEngine;


public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;

    void Start()
    {
        currentPoint = 0;
        transform.position = patrolPoints[currentPoint].position;
    }
    

    void Update()
    {
        if(transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }

        if(currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }
}
