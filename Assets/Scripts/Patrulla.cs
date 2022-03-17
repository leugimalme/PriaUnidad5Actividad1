using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    public float patrolSpeed = 0f;
    public float changeTargetDistance = 0.1f;
    public Transform[] patrolPoints;
    private Vector2 targetPosition;
    int currentTarget = 0;
    private float turnSpeed = 5;
	
    void Update()
    {
        Vector2 diff = patrolPoints[currentTarget].position - (this.transform.position);
        float angle = Mathf.Atan2(diff.y, diff.x);
        
        diff = patrolPoints[currentTarget].position - (this.transform.position);
        angle = Mathf.Atan2(diff.y, diff.x);
        
        this.transform.rotation =Quaternion.Slerp(this.transform.rotation, 
        Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg),
            turnSpeed * Time.deltaTime);

        if(MoveToTarget())
        {
            currentTarget = GetNextTarget();
        }
    }
	
    private bool MoveToTarget()
    {
        Vector3 distanceVector = patrolPoints[currentTarget].position - transform.position;
        if(distanceVector.magnitude < changeTargetDistance)
        {
            return true;
        }
			
        Vector3 velocityVector = distanceVector.normalized;
        transform.position += velocityVector * patrolSpeed * Time.deltaTime;
			
        return false;
    }
	
    private int GetNextTarget()
    {
        currentTarget++;
        if(currentTarget >= patrolPoints.Length)
        {
            currentTarget = 0;
        }
		
        return currentTarget;
    }
}
