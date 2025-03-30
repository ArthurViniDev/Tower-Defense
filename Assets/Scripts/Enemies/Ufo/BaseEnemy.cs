using System;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private int wavepointIndex = 0;
    private Transform target;

    private void Start()
    {
        target = EnemyRoute.EnemyRouteSingleton.targetPoints[wavepointIndex];
    }
    public virtual void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= .1f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        wavepointIndex++;
        target = EnemyRoute.EnemyRouteSingleton.targetPoints[wavepointIndex];
    }
}
