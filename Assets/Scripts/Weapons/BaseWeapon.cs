using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [Header("Base Weapon Store Attributes")]
    public int price = 50;
    public int refundValue = 25;

    [Header("Base Weapon Settings")]
    public GameObject bulletPrefab;
    public GameObject Target;
    public GameObject partToRotate;
    public Transform firePoint;

    [Header("Base Weapon Stats")]
    public int damage;
    public float range;
    public float attackRate;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public virtual void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range)
            {
                Target = enemy;
                return;
            }
        }
    }

    public virtual void Shoot()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
