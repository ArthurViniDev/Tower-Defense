using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    private Transform target;
    private int turretDamage;

    [SerializeField] private float speed = 10f;

    public void Seek(Transform _target, int _turretDamage)
    {
        target = _target;
        turretDamage = _turretDamage;
    }
    private void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
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
        
    }
}
