using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public int life = 100;

    private int _wavepointIndex = 0;
    public int enemyValue = 5;

    private Transform _target;

    private BaseWeapon lastWeaponAttack;

    private void Start()
    {
        _target = EnemyRoute.enemyRouteSingleton.targetPoints[_wavepointIndex];
    }
    public virtual void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * (moveSpeed * Time.deltaTime), Space.World);
        if (Vector3.Distance(transform.position, _target.position) <= .1f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int damage, BaseWeapon weapon)
    {
        life -= damage;
        lastWeaponAttack = weapon;
        if (life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GiveMoney();
        lastWeaponAttack.AddKill();
        Destroy(gameObject, .1f);
    }

    protected virtual void GiveMoney()
    {
        PlayerController.instance.money += enemyValue;
    }

    private void GetNextWaypoint()
    {
        _wavepointIndex++;
        if (_wavepointIndex >= EnemyRoute.enemyRouteSingleton.targetPoints.Count)
            return;

        _target = EnemyRoute.enemyRouteSingleton.targetPoints[_wavepointIndex];
    }
}
