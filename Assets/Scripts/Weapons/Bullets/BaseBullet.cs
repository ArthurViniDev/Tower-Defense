using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected Transform Target;
    private int _turretDamage;
    protected BaseWeapon OwnerWeapon;

    [SerializeField] private float speed = 10f;

    public void Seek(BaseWeapon ownerWeapon, Transform _target, int _turretDamage)
    {
        Target = _target;
        this._turretDamage = _turretDamage;
        OwnerWeapon = ownerWeapon;
    }

    protected virtual void Update()
    {
        if (!Target)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Vector3 dir = Target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        DestroyImmediate(gameObject);
        Target.gameObject.gameObject.GetComponent<BaseEnemy>().TakeDamage(_turretDamage, OwnerWeapon);
    }
}
