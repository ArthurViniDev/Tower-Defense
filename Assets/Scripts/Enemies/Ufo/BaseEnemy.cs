using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float startHealth = 100;
    private float health;
    public int enemyValue = 5;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Enemy Wave/Combat Settings")]
    private int _wavepointIndex = 0;
    private Transform _target;
    private BaseWeapon lastWeaponAttack;

    [Header("UI Settings")]
    [SerializeField] private Image healthBar;

    private void Start()
    {
        _target = EnemyRoute.enemyRouteSingleton.targetPoints[_wavepointIndex];
        health = startHealth;
    }

    public virtual void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * (moveSpeed * Time.deltaTime), Space.World);
        if (Vector3.Distance(transform.position, _target.position) <= .1f) GetNextWaypoint();
    }

    public void TakeDamage(int damage, BaseWeapon weapon)
    {
        healthBar.fillAmount = health / startHealth;

        health -= damage;
        lastWeaponAttack = weapon;
        if (health <= 0) Die();
    }

    private void Die()
    {
        GiveMoney();
        lastWeaponAttack.AddKill();
        Destroy(gameObject, .1f);
    }

    protected virtual void GiveMoney()
    {
        PlayerController.Instance.money += enemyValue;
    }

    private void GetNextWaypoint()
    {
        _wavepointIndex++;
        if (_wavepointIndex >= EnemyRoute.enemyRouteSingleton.targetPoints.Count) return;

        _target = EnemyRoute.enemyRouteSingleton.targetPoints[_wavepointIndex];
    }
}
