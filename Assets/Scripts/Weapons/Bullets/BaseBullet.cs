using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected Transform target;
    private int turretDamage;

    [SerializeField] private float speed = 10f;

    public void Seek(Transform _target, int _turretDamage)
    {
        target = _target;
        turretDamage = _turretDamage;
    }
    protected virtual void Update()
    {
        if (!target)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        DestroyImmediate(gameObject);
        target.gameObject.gameObject.GetComponent<BaseEnemy>().TakeDamage(turretDamage);
    }
}
