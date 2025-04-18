using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    private const string EnemyTag = "Enemy";
    private float _fireCountDown = 0f;
    protected GameObject LastBullet;

    [Header("Base Weapon Stats")]
    [SerializeField] protected float turretSpeed = 8f;
    [HideInInspector] public float fireRate = 1f;
    [SerializeField] protected int damage;
    [HideInInspector] public float range;

    [Header("Base Weapon Settings")]
    [HideInInspector] public Transform enemyTarget;
    public GameObject partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Base Weapon Store Attributes")]
    public int refundValue = 25;
    public int price = 50;
    public int killCount;

    private void Start()
    {
        PlayerController.instance.money -= price;
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    public virtual void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
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
        if (nearestEnemy != null && shortestDistance <= range) enemyTarget = nearestEnemy.transform;
        else enemyTarget = null;
    }

    public void Update()
    {
        RotateTurret();
    }

    private void RotateTurret()
    {
        if (!enemyTarget) return;

        Vector3 dir = enemyTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, turretSpeed * Time.deltaTime).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountDown <= 0f)
        {
            Shoot();
            _fireCountDown = 1f / fireRate;
        }

        _fireCountDown -= Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        LastBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void AddKill()
    {
        killCount++;
    }
}
