using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected GameObject lastBullet;

    [Header("Base Weapon Settings")]
    public GameObject bulletPrefab;
    public GameObject partToRotate;
    public Transform enemyTarget;
    public Transform firePoint;
    private const string enemyTag = "Enemy";

    [Header("Base Weapon Store Attributes")]
    public int refundValue = 25;
    public int price = 50;

    [Header("Base Weapon Stats")]
    [SerializeField] protected float turretSpeed = 8f;
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected float range;
    [SerializeField] protected int damage;

    private float fireCountDown = 0f;


    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public virtual void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            enemyTarget = nearestEnemy.transform;
        }
        else
        {
            enemyTarget = null;
        }
    }

    public void Update()
    {
        RotateTurret();
    }

    private void RotateTurret()
    {
        if (!enemyTarget)
            return;

        Vector3 dir = enemyTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, turretSpeed * Time.deltaTime).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        lastBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
