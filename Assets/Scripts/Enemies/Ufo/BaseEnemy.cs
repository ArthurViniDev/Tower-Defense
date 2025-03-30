using System;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private int life = 100;
    private int wavepointIndex = 0;
    public int enemyValue = 5;

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

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, .25f);
    }

    public virtual void GiveMoney()
    {
        PlayerController.PlayerControllerSingleton.money += enemyValue;
    }

    private void GetNextWaypoint()
    {
        wavepointIndex++;
        if (wavepointIndex >= EnemyRoute.EnemyRouteSingleton.targetPoints.Count)
            return;
        
        target = EnemyRoute.EnemyRouteSingleton.targetPoints[wavepointIndex];
    }
}
